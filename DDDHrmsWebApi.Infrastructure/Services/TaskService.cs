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
    public class TaskService : ITaskService
    {
        ApplicationDbContext db;
        IMapper mapper;
        IMemoryCache cache;
        public TaskService(ApplicationDbContext db, IMapper mapper, IMemoryCache cache)
        {
            this.db = db;
            this.mapper = mapper;
            this.cache = cache;
        }

        public void AddTask(TaskDTOSave tdto)
        {
            var task = mapper.Map<Tasks>(tdto);

            db.Tasks.Add(task);
            db.SaveChanges();


            // save task members
            foreach (var empId in tdto.EmployeeId)
            {
                TaskMembers tm = new TaskMembers()
                {
                    TaskId = task.TaskId,
                    EmployeeId = empId
                };

                db.TaskMembers.Add(tm);
            }

            db.SaveChanges();
            cache.Remove("task_list");
        }
        public List<TaskDTOFetch> FetchTask()
        {
            var cacheKey = "task_list";

            if (!cache.TryGetValue(cacheKey, out List<TaskDTOFetch>? data))
            {
                var result = db.Tasks
                    .Include(x => x.Projects)
                    .Include(x => x.Taskmembers)
                    .ThenInclude(x => x.Employee)
                    .ToList();

                data = mapper.Map<List<TaskDTOFetch>>(result);

                cache.Set(cacheKey, data,
                    TimeSpan.FromMinutes(5));
            }

            return data!;
        }
    }
}
