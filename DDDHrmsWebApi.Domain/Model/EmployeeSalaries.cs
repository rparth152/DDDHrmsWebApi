using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class EmployeeSalaries
    {
        [Key]
        public int SalaryId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalSalary { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetSalary { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedDate { get; set; }

        // Navigation properties
        public virtual Employee Employee { get; set; }

        public ICollection<EmployeeEarnings> EmployeeEarnings { get; set; }
        public ICollection<EmployeeDeductions> EmployeeDeductions { get; set; }
    }
}
