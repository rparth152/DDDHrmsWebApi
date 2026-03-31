using DDDHrmsWebApi.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.Interface
{
    public interface IEmployee
    {
         Task AddEmployee(EmployeeDTO dto);

        PagedResponse<EmpDeptDesigRole> FetchEmployee(PagedRequest request);

       
        EmployeeDTO FindEmployeeById(int id);
        Task UpdateEmployee(EmployeeDTO dto);

        bool DeleteEmployee(int id);
    }
}
