using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DDDHrmsWebApi.Domain.Model
{
    public class TaskMembers
    {

        [Key]
        public int AssignedId { get; set; }

        [ForeignKey("Task")]
        public int? TaskId { get; set; }
        [AllowNull]
        public Tasks Task { get; set; }


        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        //many users for one task --> (Taskmembers-->Task == many to one)
        public Employee Employee { get; set; }


    }
}
