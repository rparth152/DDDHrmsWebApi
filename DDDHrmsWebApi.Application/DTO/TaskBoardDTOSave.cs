using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class TaskBoardDTOSave
    {
        public int ProjectId { get; set; }

        public int TaskId { get; set; }

        public int Percentage { get; set; }

        public DateTime DueDate { get; set; }
    }
}
