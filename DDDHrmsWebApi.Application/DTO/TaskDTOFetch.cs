using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class TaskDTOFetch
    {
        public int TaskId { get; set; }

        public string Title { get; set; }

        public string ProjectName { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime Deadline { get; set; }

        public List<string> Members { get; set; }
    }
}