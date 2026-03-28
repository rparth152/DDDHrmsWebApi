using System.ComponentModel.DataAnnotations;

namespace DDDHrmsWebApi.Domain.Model
{
    public class AddDepartments
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

         public string Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public List<AddDesignation> Designations { get; set; }


    }
}
