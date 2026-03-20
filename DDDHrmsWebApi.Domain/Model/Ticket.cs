using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public string TicketTitle { get; set; }
        public string TicketDescription { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("AddDepartments")]
        public int DepartmentId { get; set; }
        public AddDepartments Department { get; set; }

        public string TicketPriority { get; set; }
        public string TicketStatus { get; set; }
        public DateTime TicketCreatedAt { get; set; }
        public string TicketAssignTo { get; set; }
    }
}
