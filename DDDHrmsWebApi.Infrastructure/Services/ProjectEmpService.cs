using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Infrastructure.Services
{
    public class ProjectEmpService : IProjectEmp
    {
        ApplicationDbContext db;
        IMapper mapper;

        public ProjectEmpService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public List<EmployeeDTOFetch> FetchEmp()
        {
            var data = db.Employee
                         .Where(x => x.RoleId == 4)
                         .Include(x => x.AddRole)
                         .ToList();

            return mapper.Map<List<EmployeeDTOFetch>>(data);
        }
    }
}
