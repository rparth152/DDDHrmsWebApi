using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class Resignation
    {
        [Key]
        public int ResignationId { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        [ForeignKey("AddDesignation")]
        public int DesignationId { get; set; }
        public AddDesignation Designation { get; set; }

        [Required]
        [ForeignKey("AddDepartments")]
        public int DepartmentId { get; set; }
        public AddDepartments Department { get; set; }

        [Required]
        public DateTime NoticeDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ResignDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(500)]
        public string ResignReason { get; set; }
        [Required]
        [StringLength(50)]
        public string ResignStatus { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

    }
}
