using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Domain.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.Interface
{
    public interface IDepartments
    {
        void AddDepartment(DepartmentDTO dto);

        List<DepartmentDTO> GetAllDepartments();
        PagedResponse<DepartmentDTO> FetchDepartment(PagedRequest request);
        DepartmentDTO FindDeptById(int id);
        void UpdateDeptment(DepartmentDTO dto);

        bool DeleteDepartment(int id);
        
    }
}
