using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class TaskBoards
    {


        [Key]
        public int TaskBoardId { get; set; }

        [ForeignKey("Projects")]
        public int ProjectId { get; set; }

        //taskboard have one project (taskboard-->project== many to one )
        public Projects Projects { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }

        //taskboard have one task  (taskboard-->task== many to one )
        public Tasks Tasks { get; set; }

        [Range(0, 100)]
        public int Percentage { get; set; }

        [Required]
        public DateTime DueDate { get; set; }



    }

}
