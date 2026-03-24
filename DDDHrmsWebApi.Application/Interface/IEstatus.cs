using DDDHrmsWebApi.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.Interface
{
    public interface IEstatus
    {
        public List<FetchAttendance> FAttendance();
        public List<FetchEmpDTO> Employees();
        public List<FetchLeaves> Leaves();
        //public List<EstatusDTO> Estatus();
        //public int ActiveEmployees();
        //public int EmployeeCount();
        //public int InactiveEmployees();
        byte[] ExportEmployeesToCSV();
        byte[] ExportEmployeesToPDF();
        public EstatusDTO Fetchdata();
    }
}
