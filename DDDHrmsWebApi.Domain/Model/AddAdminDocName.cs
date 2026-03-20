using System.ComponentModel.DataAnnotations;

namespace DDDHrmsWebApi.Domain.Model    
{
    public class AddAdminDocName
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "DocName is required.")]
        public string DocName { get; set; }

    }
}
