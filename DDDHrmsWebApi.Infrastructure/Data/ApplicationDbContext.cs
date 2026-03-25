using DDDHrmsWebApi.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace DDDHrmsWebApi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<AddDepartments> AddDepartments { get; set; }
        public DbSet<AddDesignation> AddDesignation { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<AddRole> AddRole { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<Resignation> Resignation { get; set; }
        public DbSet<AddAdminDocName> AddAdminDocName { get; set; }
        public DbSet<AddEmployeeDocName> AddEmployeeDocName { get; set; }
        public DbSet<AddEventType> AddEventType { get; set; }
        public DbSet<AddNewEvent> AddNewEvent { get; set; }
        public DbSet<AddTrainer> AddTrainer { get; set; }
        public DbSet<AddTrainingList> AddTrainingLists { get; set; }
        public DbSet<AddTrainingType> AddTrainingType { get; set; }
        public DbSet<AdminDocuments> AdminDocuments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Deduction> Deduction { get; set; }
        public DbSet<DeductionType> DeductionType { get; set; }
        public DbSet<DepartmentLeaves> DepartmentLeaves { get; set; }
        public DbSet<Earning> Earning { get; set; }
        public DbSet<EarningType> EarningType { get; set; }
        public DbSet<EmpBankDetails> EmpBankDetailss { get; set; }
        public DbSet<EmpEducationInfo> EmpEducationInfo { get; set; }
        public DbSet<EmpExperience> EmpExperience { get; set; }
        public DbSet<EmpFamilyInfo> EmpFamilyInfo { get; set; }
        public DbSet<EmployeeDeductions> EmployeeDeductions { get; set; }
        public DbSet<EmployeeEarnings> EmployeeEarnings { get; set; }
        public DbSet<EmployeeSalaries> EmployeeSalaries { get; set; }
        public DbSet<LeaveBalance> LeaveBalance { get; set; }
        public DbSet<LeaveRequest> LeaveRequest { get; set; }
        public DbSet<MasterLeaveType> MasterLeaveType { get; set; }
        public DbSet<Payslips> Payslips { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<TaskBoards> TaskBoards { get; set; }
        public DbSet<TaskMembers> TaskMembers { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Termination> Termination { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Timesheet> Timesheet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasOne(x => x.AddDepartments)
            .WithMany()
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.AddDesignation)
                .WithMany()
                .HasForeignKey(x => x.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.AddRole)
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Earning>()
            .Property(e => e.EarningsPercentage)
            .HasPrecision(5, 2);

            modelBuilder.Entity<Promotion>(p =>
            {
                // promotion has one to one mapping 
                p.HasOne(x => x.Employee)
                .WithMany()
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

                p.HasOne(x => x.Designation)
                .WithMany()
                .HasForeignKey(x => x.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

                p.HasOne(x => x.Department)
                .WithMany()
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Resignation>(r =>
            {
                r.HasOne(x => x.Employee)
                .WithMany()
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

                r.HasOne(x => x.Designation)
                .WithMany()
                .HasForeignKey(x => x.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

                r.HasOne(x => x.Department)
                .WithMany()
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Termination>(t =>
            {
                t.HasOne(x => x.Employee)
                .WithMany()
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(x => x.Resignation)
                .WithMany()
                .HasForeignKey(x => x.ResignationId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Ticket>(t =>
            {
                t.HasOne(x => x.Employee)
                .WithMany()
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(x => x.Department)
                .WithMany()
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            // TaskBoards -> Task (Restrict delete to avoid multiple cascading paths)
            modelBuilder.Entity<TaskBoards>()
              .HasOne(t => t.Tasks)
                .WithMany()
                .HasForeignKey(t => t.TaskId)
                .OnDelete(DeleteBehavior.Restrict);

            // TaskBoards -> Projects (Restrict delete to avoid multiple cascading paths)
            modelBuilder.Entity<TaskBoards>()
                .HasOne(t => t.Projects)
                .WithMany()
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); // Fix: Avoid cascading delete

            // Tasks -> Projects (Ensure foreign key constraint is properly configured)
            modelBuilder.Entity<Tasks>()
           .HasOne(t => t.Projects)
           .WithMany(p => p.Tasks)
           .HasForeignKey(t => t.ProjectId)
           .OnDelete(DeleteBehavior.Restrict); // Fix: Avoid cascading delete

            modelBuilder.Entity<Deduction>()
           .HasOne(d => d.Designation)
           .WithMany()
           .HasForeignKey(d => d.DesignationId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Earning>()
           .HasOne(e => e.Department)
           .WithMany()
           .HasForeignKey(e => e.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Earning>()
           .HasOne(e => e.Designation)
           .WithMany()
           .HasForeignKey(e => e.DesignationId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Earning>()
           .HasOne(e => e.EarningType)
           .WithMany()
           .HasForeignKey(e => e.EarntypeId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LeaveBalance>()
           .HasOne(lb => lb.Employee)
           .WithMany()
           .HasForeignKey(lb => lb.EmployeeId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LeaveBalance>()
           .HasOne(lb => lb.DepartmentLeaves)
           .WithMany()
           .HasForeignKey(lb => lb.DepartmentLeavesId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaveBalance>()
           .HasOne(lb => lb.MasterLeaveType)
           .WithMany()
           .HasForeignKey(lb => lb.LeaveTypeId)
           .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

