using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class ProjectDTOSave
    {
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Priority { get; set; }
        public double ProjectValue { get; set; }
        public string PriceType { get; set; }

        public string FilePath { get; set; }
        public string LogoPath { get; set; }

        public string Status { get; set; }

        // Manager selection
        public int ManagerId { get; set; }

        // Multiple employees selection
        public List<int> EmployeeId { get; set; }
    }
}
