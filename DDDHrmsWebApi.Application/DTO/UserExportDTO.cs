using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class UserExportDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string ContactNumber { get; set; }
        public string JoiningDate { get; set; }
        public string Status { get; set; }
    }
}
