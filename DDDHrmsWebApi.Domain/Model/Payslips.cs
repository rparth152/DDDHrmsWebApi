using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class Payslips
    {
        [Key]
        public int PayslipId { get; set; }

        [ForeignKey("Employee")]
        [Required(ErrorMessage = "User is required.")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required(ErrorMessage = "Month is required.")]
        public string Month { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(2000, 2100, ErrorMessage = "Year must be between 2000 and 2100.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Payslip path is required.")]
        public string PayslipPath { get; set; }

        [Required]
        public DateTime GeneratedOn { get; set; }
    }
}
