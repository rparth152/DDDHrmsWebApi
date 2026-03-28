using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class DesignationDTO
    {
        public int DesignationId { get; set; }

        public string DesignationName { get; set; }
        public string Status { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public int DepartmentId { get; set; }

        //public string DepartmentName { get; set; }


    }
}
