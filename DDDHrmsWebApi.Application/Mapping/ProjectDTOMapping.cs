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
    public class ProjectDTOMapping : Profile
    {
        public ProjectDTOMapping()
        {
            //Projects
            CreateMap<ProjectDTOSave, Projects>().ReverseMap();

            CreateMap<Projects, ProjectDTOFetch>()
            .ForMember(x1 => x1.ManagerName,
            x2 => x2.MapFrom(x3 =>
            x3.Manager.FirstName + " " + x3.Manager.LastName))

            .ForMember(x1 => x1.Employees,
            x2 => x2.MapFrom(x3 =>
            x3.Employee.Select(x4 =>
            x4.FirstName + " " + x4.LastName).ToList()
            ));
        }
    }
}
