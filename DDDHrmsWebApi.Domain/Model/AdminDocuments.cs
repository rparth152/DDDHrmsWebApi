using System.ComponentModel.DataAnnotations;

namespace DDDHrmsWebApi.Domain.Model
{
    public class AdminDocuments
    {

        [Key]
        public int AdminDocId { get; set; }
        public string Email { get; set; }
        public string DocName { get; set; }
        public string DocFile { get; set; }
    }
}
