using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class EmpFamilyInfo
    {
        [Key]
        public int FInfoId { get; set; }

        public string Name { get; set; }
        public string RelationShip { get; set; }
        public string ContactNumber { get; set; }
        public DateTime BirthDate { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
