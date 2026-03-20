using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class AddTrainer
    {
        [Key]
        public int TrainerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PhoneNUmber { get; set; }

        public string UploadImage { get; set; }

        [ForeignKey("AddRole")]
        public int RoleId { get; set; }

        public AddRole AddRole { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

    }
}
