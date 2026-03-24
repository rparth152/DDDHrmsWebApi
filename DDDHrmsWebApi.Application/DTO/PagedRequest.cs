using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class PagedRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        public string SortBy { get; set; } = "DesignationName";
        public string SortOrder { get; set; } = "asc"; // asc / desc

        public string SearchText { get; set; }

        public string Status { get; set; }
    }
}
