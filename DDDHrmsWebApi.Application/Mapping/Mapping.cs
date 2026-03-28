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
        }
    }
}
