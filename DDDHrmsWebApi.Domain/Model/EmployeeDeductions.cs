using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class EmployeeDeductions
    {
        [Key]
        public int EmployeeDeductionId { get; set; }

        [ForeignKey("EmployeeSalaries")]
        public int SalaryId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Deduction")]
        public int DeductionId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DeductionAmount { get; set; }

        // Navigation properties
        public virtual EmployeeSalaries EmployeeSalaries { get; set; }
        public virtual Deduction Deduction { get; set; }
    }
}
