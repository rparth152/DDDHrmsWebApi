using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class AddTrainingList
    {
        [Key]
        public int TraniningId { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }

        public AddTrainer Trainer { get; set; }

        [ForeignKey("Training")]
        public int TrainingTypeId { get; set; }

        public AddTrainingType Training { get; set; }

        [ForeignKey("employee")]
        public int EmployeeId { get; set; }

        public Employee employee { get; set; }

        public int TrainingCost { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

    }
}
