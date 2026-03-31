using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class ProjectTable
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime Deadline { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}
