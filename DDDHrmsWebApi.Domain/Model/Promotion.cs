using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class Promotion
    {
        [Key]
        public int PromotionId { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        [ForeignKey("AddDepartments")]
        public int DepartmentId { get; set; }
        public AddDepartments Department { get; set; }

        [Required]
        [ForeignKey("AddDesignation")]
        public int DesignationId { get; set; }
        public AddDesignation Designation { get; set; }

        [Required]
        [StringLength(100)]
        public string DesignationFrom { get; set; }

        [Required]
        [StringLength(100)]
        public string DesignationTo { get; set; }

        [Required]
        public DateTime PromotionDate { get; set; } = DateTime.Now;

        [StringLength(500)]
        public string PromotionReason { get; set; }
    }
}
