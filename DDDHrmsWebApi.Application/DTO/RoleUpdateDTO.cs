using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class RoleUpdateDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public string Status { get; set; }
    }
}
