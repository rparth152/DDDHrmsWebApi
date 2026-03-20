using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class Termination
    {
        [Key]
        public int TerminationId { get; set; }

        // FK 1: Employee
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        [ForeignKey("Resignation")]
        public int ResignationId { get; set; }
        public Resignation Resignation { get; set; }

        [Required]
        [StringLength(100)]
        public string TerminationType { get; set; }


        [Required]
        [StringLength(500)]
        public string TerminationReason { get; set; }

        [Required]
        public DateTime TerminatNoticeDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime TerminationDate { get; set; } = DateTime.Now;
    }
}
