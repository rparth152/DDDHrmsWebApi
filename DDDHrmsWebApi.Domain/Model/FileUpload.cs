using System.ComponentModel.DataAnnotations.Schema;

namespace DDDHrmsWebApi.Domain.Model
{
    public class FileUpload
    {
        public int id { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        //many files can have one Employee --> (navigation Many fileupload --> one Employee)   many to one  relation 
        public Employee Employee { get; set; }


    }
}
