using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class AddNewEvent
    {
        [Key]
        public int EventId { get; set; }

        public string EventTitle { get; set; }

        public DateOnly EventDate { get; set; }

        [ForeignKey("EventType")]
        public int EventTypeId { get; set; }

        public AddEventType EventType { get; set; }
    }
}
