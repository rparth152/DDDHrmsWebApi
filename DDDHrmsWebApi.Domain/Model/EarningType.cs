using System.ComponentModel.DataAnnotations;

namespace DDDHrmsWebApi.Domain.Model
{
    public class EarningType
    {
        [Key]
        public int EarntypeId { get; set; }
        public string EarningName { get; set; }

        public List<Earning> Earnings { get; set; }
    }
}
