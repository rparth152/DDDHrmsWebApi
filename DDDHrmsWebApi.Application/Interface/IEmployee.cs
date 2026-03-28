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
        void AddEmployee(EmployeeDTO dto);

        List<EmpDeptDesigRole> FetchEmployee();

        EmployeeDTO FindEmployeeById(int id);
        void UpdateEmployee(EmployeeDTO dto);

        bool DeleteEmployee(int id);
    }
}
