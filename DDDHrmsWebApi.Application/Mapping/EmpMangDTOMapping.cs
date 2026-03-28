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
    public class EmpMangDTOMapping : Profile
    {
        public EmpMangDTOMapping()
        {
            CreateMap<Employee, EmployeeDTOFetch>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))

                .ForMember(dest => dest.RoleName,
                    opt => opt.MapFrom(src => src.AddRole.RoleName));

            CreateMap<Employee, ManagerDTOFetch>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))

                .ForMember(dest => dest.RoleName,
                    opt => opt.MapFrom(src => src.AddRole.RoleName));
        }
    }
}
