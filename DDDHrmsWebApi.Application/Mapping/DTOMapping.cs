using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.Mapping
{
    public class DTOMapping : Profile
    {
        public DTOMapping() {
            CreateMap<AddDepartments, RoleDTO>().ReverseMap();
           

            CreateMap<AddRole, RoleDTO>().ReverseMap();
            CreateMap<AddRole, RoleUpdateDTO>().ReverseMap();

            CreateMap<AddDepartments, DepartmentDTO>().ReverseMap();

            CreateMap<AddDesignation, DesignationDTO>().ReverseMap();

            CreateMap<AddDesignation, DesignationDeptDTO>().ForMember(x => x.DepartmentName,
                x => x.MapFrom(x => x.AddDepartments != null ? x.AddDepartments.DepartmentName : "No Dept"));

            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<Employee, EmpDeptDesigRole>()
             .ForMember(dept => dept.DepartmentName, o => o.MapFrom(s => s.AddDepartments.DepartmentName))
    .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.AddRole.RoleName))
    .ForMember(dest => dest.DesignationName, opt => opt.MapFrom(src => src.AddDesignation.DesignationName));

        }
       
    }
}
