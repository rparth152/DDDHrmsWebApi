using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Infrastructure.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Caching.Memory;
using Document = iTextSharp.text.Document;

namespace DDDHrmsWebApi.Infrastructure.Services
{
    public class Estatus : IEstatus
    {
        IMemoryCache cache;
        ApplicationDbContext db;
        IMapper mapper;
        public Estatus(ApplicationDbContext db, IMapper mapper, IMemoryCache cache) {
            this.db = db;
            this.mapper = mapper;
            this.cache = cache;
        }

        public List<FetchEmpDTO> Employees()
        {
            if (!cache.TryGetValue("employees", out List<FetchEmpDTO> data))
            {
                data = mapper.Map<List<FetchEmpDTO>>(db.Employee.ToList());

                var options = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                cache.Set("employees", data, options);
            }

            return data;
        }
        List<FetchAttendance> IEstatus.FAttendance()
        {
            var data = mapper.Map<List<FetchAttendance>>(db.Attendances.ToList());
            return data;
        }

        //public int ActiveEmployees()
        //{
        //    var sactive = db.Employee.Where(x => x.Status == "Active").Count();
        //    return sactive;
        //}

        //public int EmployeeCount()
        //{
        //    throw new NotImplementedException();
        //}

        public EstatusDTO Fetchdata()//status graph
        {
            return new EstatusDTO
            {
                sactive = db.Employee.Where(x => x.Status == "Active").Count(),
                ecount = db.Employee.Count(),
                sinactive = db.Employee.Where(x => x.Status == "Inactive").Count(),
            };
        }

        public List<FetchLeaves> Leaves()
        {
            var data = mapper.Map<List<FetchLeaves>>(db.LeaveRequest.ToList());
            return data;
        }
        public Fcount Lcount() {
            return new Fcount
            {

                Leaveactive = db.LeaveRequest.Where(x => x.Status == "Active").Count(),
                Leave = db.LeaveRequest.Count(),
                Leaveinactive = db.LeaveRequest.Where(x => x.Status == "Inactive").Count(),
            };
        }
        public List<AttendenceGraph> attendencegraph() { 
            var Data = db.Attendances.Select(a => new AttendenceGraph
            {
                CheckIn = a.CheckIn,
            }).ToList();
            return Data;
        }
        public ProjectDTO projectgraph() {
            return new ProjectDTO {
                ProjActive = db.Projects.Where(x => x.Status == "Active").Count(),
                ProjInactive = db.Projects.Where(x => x.Status == "Inactive").Count(),
            };
        }
        public List<ProjectTable> Projtable() {
            var data = mapper.Map<List<ProjectTable>>(db.Projects.ToList());
            return data;
        }
        public TaskDTO Taskgraph() {
            return new TaskDTO
            {
                TaskActive = db.Projects.Where(x => x.Status == "Active").Count(),
                TaskInactive = db.Projects.Where(x => x.Status == "Inactive").Count(),
            };
        }
        public List<TaskTable> Tasktable() {
            var data = mapper.Map<List<TaskTable>>(db.Tasks.ToList());
            return data;
        }
        public byte[] ExportEmployeesToCSV()
        {
            var employees = mapper
                .ProjectTo<UserExportDTO>(db.Employee)
                .ToList();

            var builder = new StringBuilder();
            builder.AppendLine("EmployeeId,Name,Email,Department,Contact Number,Joining Date,Status");

            foreach (var emp in employees)
            {
                builder.AppendLine($"{emp.EmployeeId},{emp.FirstName},{emp.Email},{emp.Department},{emp.ContactNumber},{emp.JoiningDate},{emp.Status}");
            }

            return Encoding.UTF8.GetBytes(builder.ToString());
        }

        public byte[] ExportEmployeesToPDF()
        {
            var employees = mapper
                .ProjectTo<UserExportDTO>(db.Employee)
                .ToList();

            using (var stream = new MemoryStream())
            {
                var document = new Document();
                PdfWriter.GetInstance(document, stream).CloseStream = false;
                document.Open();

                // Title
                var title = new Paragraph("Employee Report",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
                {
                    Alignment = Element.ALIGN_CENTER
                };

                document.Add(title);
                document.Add(new Paragraph(" "));

                // Table
                var table = new PdfPTable(7) { WidthPercentage = 100 };

                table.AddCell("EmployeeId");
                table.AddCell("Name");
                table.AddCell("Email");
                table.AddCell("Department");
                table.AddCell("Contact Number");
                table.AddCell("Joining Date");
                table.AddCell("Status");

                foreach (var emp in employees)
                {
                    table.AddCell(emp.EmployeeId.ToString());
                    table.AddCell(emp.FirstName);
                    table.AddCell(emp.Email);
                    table.AddCell(emp.Department);
                    table.AddCell(emp.ContactNumber);
                    table.AddCell(emp.JoiningDate);
                    table.AddCell(emp.Status);
                }

                document.Add(table);
                document.Close();

                return stream.ToArray();
            }
        }

        //public int InactiveEmployees()
        //{
        //    var sinactive = db.Employee.Where(x => x.Status == "Inactive").Count();
        //    return sinactive;
        //}

        //List<EstatusDTO> IEstatus.Estatus()
        //{


        //    var data = db.Employee.Select(e => new EstatusDTO { EmployeeId = e.EmployeeId, Status = e.Status }).ToList();
        //    return data;
        //}


    }
}
