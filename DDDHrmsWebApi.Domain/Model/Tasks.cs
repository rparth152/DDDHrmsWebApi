using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class Tasks
    {


        [Key]
        public int TaskId { get; set; }

        // Foreign Key Definition
        [ForeignKey("Project")]
        public int ProjectId { get; set; }


        //one project 
        public Projects Projects { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [StringLength(50)]
        public string Priority { get; set; }

        [StringLength(255)]
        public string? FilePath { get; set; }

        [Required]
        public DateTime Deadline { get; set; }


        //one task have multipe taskboards --> (Task-->Taskboard== one to many )
        public List<TaskBoards> TaskBoards { get; set; }

        //one task can assign many TaskMembers(users) -- > (Task --> Users == one to many)
        public List<TaskMembers> Taskmembers { get; set; }




    }
}
