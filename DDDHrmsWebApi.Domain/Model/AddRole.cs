using System.ComponentModel.DataAnnotations;

namespace DDDHrmsWebApi.Domain.Model
{
    public class AddRole
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
