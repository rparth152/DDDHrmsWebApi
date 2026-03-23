using DDDHrmsWebApi.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class FetchLeaves
    {
        public int LeaveRequestId { get; set; }

        public int EmployeeId { get; set; }
         
        public int LeaveTypeId { get; set; }
        

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int NumberOfDays { get; set; }

        public string Reason { get; set; }

        public string ApprovedBy { get; set; }

        public string Status { get; set; }
        public string StatusHistory { get; set; }
    }
}
