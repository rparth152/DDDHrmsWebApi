using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class AddDesignation
    {
        [Key]
        public int DesignationId { get; set; }

        public string DesignationName { get; set; }
        public string Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        [ForeignKey("AddDepartments")]
        public int DepartmentId { get; set; }
        public AddDepartments AddDepartments { get; set; }
    }
}

