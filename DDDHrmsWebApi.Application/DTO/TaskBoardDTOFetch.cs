using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class TaskBoardDTOFetch
    {
        public int TaskBoardId { get; set; }

        public string ProjectName { get; set; }

        public string TaskName { get; set; }

        public int Percentage { get; set; }

        public DateTime DueDate { get; set; }
    }
}
