using System.ComponentModel.DataAnnotations;

namespace DDDHrmsWebApi.Domain.Model
{
    public class DeductionType
    {
        [Key]
        public int DeductionTypeId { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string DeductionsName { get; set; }

        // Navigation property
        public virtual ICollection<Deduction> Deductions { get; set; }
    }
}
