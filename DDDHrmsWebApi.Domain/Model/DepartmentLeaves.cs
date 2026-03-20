using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class DepartmentLeaves
    {
        [Key]
        public int DepartmentLeavesId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public AddDepartments Department { get; set; }

        [ForeignKey("MasterLeaveType")]
        public int LeaveTypeId { get; set; }
        public MasterLeaveType MasterLeaveType { get; set; }
        //public string LeaveType { get; set; } 
        public int LeavesCount { get; set; }
        public string Status { get; set; }
    }
}
