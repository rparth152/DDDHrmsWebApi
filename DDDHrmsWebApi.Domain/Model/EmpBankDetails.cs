using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class EmpBankDetails
    {
        [Key]
        public int EmpBankDetailsId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string BranchAddress { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
