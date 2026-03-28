using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Domain.Model;
using DDDHrmsWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace DDDHrmsWebApi.Infrastructure.Services
{
    public class TaskBoardService : ITaskBoardService
    {
        ApplicationDbContext db;
        IMapper mapper;
        IMemoryCache cache;

        public TaskBoardService(ApplicationDbContext db, IMapper mapper, IMemoryCache cache)
        {
            this.db = db;
            this.mapper = mapper;
            this.cache = cache;
        }

        public void AddTaskBoard(TaskBoardDTOSave tbdto)
        {
            var data = mapper.Map<TaskBoards>(tbdto);

            db.TaskBoards.Add(data);
            db.SaveChanges();
        }

        public List<TaskBoardDTOFetch> FetchTaskBoard()
        {
            var data = db.TaskBoards
                .Include(x => x.Projects)
                .Include(x => x.Tasks)
                .ToList();

            return mapper.Map<List<TaskBoardDTOFetch>>(data);
        }
    }
}