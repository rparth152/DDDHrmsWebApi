using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime BirthDate { get; set; }

        [ForeignKey("AddDepartments")]
        public int DepartmentId { get; set; }
        public AddDepartments AddDepartments { get; set; }

        [ForeignKey("AddRole")]
        public int RoleId { get; set; }
        public AddRole AddRole { get; set; }

        [ForeignKey("AddDesignation")]
        public int DesignationId { get; set; }
        public AddDesignation AddDesignation { get; set; }

        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string About { get; set; }

        //Added For Projects - Saurabh
        public int? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Projects Projects { get; set; } 

    }
}
