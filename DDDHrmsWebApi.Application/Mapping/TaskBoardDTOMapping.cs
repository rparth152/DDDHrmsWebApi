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
    public class TaskBoardDTOMapping : Profile
    {
        public TaskBoardDTOMapping()
        {
            CreateMap<TaskBoardDTOSave, TaskBoards>();

            CreateMap<TaskBoards, TaskBoardDTOFetch>()
            .ForMember(x => x.ProjectName,
            o => o.MapFrom(s => s.Projects.ProjectName))

            .ForMember(x => x.TaskName,
            o => o.MapFrom(s => s.Tasks.Title));
        }
    }
}
