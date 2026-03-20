using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class Deduction
    {
        [Key]
        public int DeductionId { get; set; } // Primary Key

        [ForeignKey("DeductionType")]
        public int DeductionTypeId { get; set; } // Foreign Key to DeductionType
        [ForeignKey("Department")]
        public int DepartmentId { get; set; } // Foreign Key to Department
        [ForeignKey("Designation")]

        public int DesignationId { get; set; } // Foreign Key to Designation

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal DeductionPercentage { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; } // Foreign Key to User who created the record

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; } // Foreign Key to User who modified the record

        // Navigation properties
        public virtual DeductionType DeductionType { get; set; }
        public virtual AddDepartments Department { get; set; }
        public virtual AddDesignation Designation { get; set; }
    }
}
