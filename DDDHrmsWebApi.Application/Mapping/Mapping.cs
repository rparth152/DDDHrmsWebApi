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
    public class Mapping : Profile
    {
        public Mapping()
        {
            
            CreateMap<Employee, FetchEmpDTO>();
            CreateMap<Attendance, FetchAttendance>();
            CreateMap<LeaveRequest, FetchLeaves>();
            // CreateMap<Source, Destination>();
            // Example: CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, UserExportDTO>()
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest => dest.Department,
                opt => opt.MapFrom(src => src.AddDepartments.DepartmentName))
            .ForMember(dest => dest.JoiningDate,
                opt => opt.MapFrom(src => src.JoiningDate.ToString("yyyy-MM-dd")));
            CreateMap<Projects, ProjectTable>();
            CreateMap<Tasks, TaskTable>();
        }
    }
}
