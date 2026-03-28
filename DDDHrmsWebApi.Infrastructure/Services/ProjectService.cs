using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Domain.Model;
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
    public class ProjectService : IProjectService
    {
        ApplicationDbContext db;
        IMapper mapper;
        IMemoryCache cache;
        public ProjectService(ApplicationDbContext db, IMapper mapper, IMemoryCache cache)
        {
            this.db = db;
            this.mapper = mapper;
            this.cache = cache;
        }
        public void AddProject(ProjectDTOSave dto)
        {
            var project = mapper.Map<Projects>(dto);

            // save project FIRST
            db.Projects.Add(project);
            db.SaveChanges();


            // now assign employees
            var employees = db.Employee
                .Where(x => dto.EmployeeId.Contains(x.EmployeeId))
                .ToList();

            foreach (var emp in employees)
            {
                emp.ProjectId = project.ProjectId;
            }

            db.SaveChanges();
        }

        public List<ProjectDTOFetch> FetchProject()
        {
            var data = db.Projects
                .Include(x => x.Manager)
                .Include(x => x.Employee)
                .ToList();

            return mapper.Map<List<ProjectDTOFetch>>(data);
        }
    }
}
