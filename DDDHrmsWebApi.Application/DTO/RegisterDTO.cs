using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        //public int RoleId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? RoleId { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }


    }
}
