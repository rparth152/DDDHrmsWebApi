using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Infrastructure.Services
{
    public class ProjectMangService : IProjectMang
    {
        ApplicationDbContext db;
        IMapper mapper;

        public ProjectMangService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public List<ManagerDTOFetch> FetchManager()
        {
            var data = db.Employee
                         .Where(x => x.RoleId == 2)
                         .Include(x => x.AddRole)
                         .ToList();

            return mapper.Map<List<ManagerDTOFetch>>(data);
        }
    }
}
