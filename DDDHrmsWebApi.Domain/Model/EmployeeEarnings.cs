using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class EmployeeEarnings
    {
        [Key]
        public int EmployeeEarningId { get; set; }

        [ForeignKey("EmployeeSalaries")]
        public int SalaryId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Earning")]
        public int EarningId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal EarningAmount { get; set; }

        // Navigation properties
        public virtual EmployeeSalaries EmployeeSalaries { get; set; }
        public virtual Earning Earning { get; set; }
    }
}
