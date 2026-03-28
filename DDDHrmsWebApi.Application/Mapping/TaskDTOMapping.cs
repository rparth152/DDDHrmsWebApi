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
    public class TaskDTOMapping : Profile
    {
        public TaskDTOMapping()
        {
            CreateMap<TaskDTOSave, Tasks>()
            .ForMember(dest => dest.Taskmembers, opt => opt.Ignore());


            CreateMap<Tasks, TaskDTOFetch>()
            .ForMember(d => d.ProjectName,o => o.MapFrom(s => s.Projects.ProjectName))

            .ForMember(d => d.Members,o => o.MapFrom(s => s.Taskmembers
            .Select(x => x.Employee.FirstName + " " + x.Employee.LastName)
            .ToList()));
        }
    }
}
