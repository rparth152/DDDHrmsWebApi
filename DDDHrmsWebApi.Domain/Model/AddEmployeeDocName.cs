using System.ComponentModel.DataAnnotations;

namespace DDDHrmsWebApi.Domain.Model
{
    public class AddEmployeeDocName
    {
        [Key]
        public int Id { get; set; }
        public string DocName { get; set; }

    }
}
