using System.ComponentModel.DataAnnotations;

namespace DDDHrmsWebApi.Domain.Model
{
    public class AddEventType
    {
        [Key]
        public int EventTypeId { get; set; }

        public string EventTypeName { get; set; }

        public string Color { get; set; }
    }
}
