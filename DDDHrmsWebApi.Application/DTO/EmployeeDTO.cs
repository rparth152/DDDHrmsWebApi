using DDDHrmsWebApi.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime BirthDate { get; set; }

       
        public int DepartmentId { get; set; }
       

       
        public int RoleId { get; set; }
     
       
        public int DesignationId { get; set; }
     

        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string About { get; set; }

      
    }
}
