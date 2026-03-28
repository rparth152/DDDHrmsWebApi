using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class TaskDTOSave
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime Deadline { get; set; }

        public string? FilePath { get; set; }

        // selected project
        public int ProjectId { get; set; }

        // selected team members
        public List<int> EmployeeId { get; set; }
    }
}