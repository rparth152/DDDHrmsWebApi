using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Infrastructure.Services
{
    public class Estatus : IEstatus
    {
        ApplicationDbContext db;
        IMapper mapper;
        public Estatus(ApplicationDbContext db, IMapper mapper) {
            this.db = db;
            this.mapper = mapper;
        }

        public List<FetchEmpDTO> Employees()
        {
            var data= mapper.Map<List<FetchEmpDTO>>(db.Employee.ToList());
            return data;
        }
        List<FetchAttendance> IEstatus.FAttendance()
        {
            var data = db.Attendances.Select(e => new FetchAttendance {
                AttendanceId = e.AttendanceId,
                EmployeeId = e.EmployeeId,
                Date = e.Date,
                CheckIn = e.CheckIn,
                CheckOut = e.CheckOut,
                LunchIn = e.LunchIn,
                LunchOut = e.LunchOut,
                WorkingHours = e.WorkingHours,
                ProductionHours = e.ProductionHours,
                OvertimeHours = e.OvertimeHours,
                BreakHours = e.BreakHours,
                Late = e.Late,
                Status = e.Status,
               
            }).ToList();
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
            var data = db.LeaveRequest.Select(e => new FetchLeaves
            {
            LeaveRequestId = e.LeaveRequestId,
            EmployeeId = e.EmployeeId,
            
            LeaveTypeId = e.LeaveTypeId,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            NumberOfDays = e.NumberOfDays,
            Reason = e.Reason,
            ApprovedBy = e.ApprovedBy,
            Status = e.Status,
            StatusHistory = e.StatusHistory,

            }
            ).ToList();
            return data;
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
