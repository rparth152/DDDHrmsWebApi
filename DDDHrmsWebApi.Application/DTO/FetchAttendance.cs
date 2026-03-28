using DDDHrmsWebApi.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class FetchAttendance
    {
        public int AttendanceId { get; set; }

        public int EmployeeId { get; set; }
       
        public DateTime Date { get; set; }

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public DateTime? LunchIn { get; set; }

        public DateTime? LunchOut { get; set; }

        public decimal WorkingHours { get; set; }

        public decimal ProductionHours { get; set; }

        public decimal OvertimeHours { get; set; }

        public decimal BreakHours { get; set; }

        public int Late { get; set; }

        public string Status { get; set; }

        
    }
}
