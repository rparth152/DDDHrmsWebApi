using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.DTO
{
    public class PagedResponse<T>
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }

        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
        public List<T> Data { get; set; }
    }
}