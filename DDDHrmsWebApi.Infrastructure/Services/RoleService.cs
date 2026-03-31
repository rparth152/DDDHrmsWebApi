using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Domain.Model;
using DDDHrmsWebApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Infrastructure.Services
{
    public class RoleService : IRole
    {
        ApplicationDbContext db;
        IMapper mapper;
        public RoleService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void AddRole(RoleDTO dto)
        {
            var role = mapper.Map<AddRole>(dto);
            db.AddRole.Add(role);
            db.SaveChanges();

        }

        public bool DeleteRole(int id)
        {
            var data = db.AddRole.Find(id);

            if (data == null)
            {

                return false;
            }

            db.AddRole.Remove(data);
            db.SaveChanges();

            return true;
        }

        //public List<RoleDTO> FetchRole()
        //{
        //    var data = db.AddRole.ToList();
        //    var res = mapper.Map<List<RoleDTO>>(data);
        //    return res;
        //}

        public PagedResponse<RoleDTO> FetchRole(PagedRequest request)
        {
            var query = db.AddRole.AsQueryable();

            query = query.Where(x => (string.IsNullOrWhiteSpace(request.SearchText) ||
           (x.RoleName != null && x.RoleName.ToLower().Contains(request.SearchText.Trim().ToLower())))
              &&
           (string.IsNullOrWhiteSpace(request.Status) || (x.Status != null && x.Status.ToLower() == request.Status.Trim().ToLower())));

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                var sortOrder = request.SortOrder?.ToLower() == "desc" ? "descending" : "ascending";

                if (request.SortBy == "RoleName" || request.SortBy == "Status")
                {
                    query = query.OrderBy($"{request.SortBy} {sortOrder}");
                }
                else
                {
                    query = query.OrderBy("RoleName ascending");
                }
            }
            else
            {
                query = query.OrderBy("RoleName ascending");
            }   

            var totalRecords = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / request.PageSize);

            var data = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var result = mapper.Map<List<RoleDTO>>(data);

            return new PagedResponse<RoleDTO>
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                HasNext = request.PageNumber < totalPages,
                HasPrevious = request.PageNumber > 1,
                NextPage = request.PageNumber < totalPages ? request.PageNumber + 1 : null,
                PreviousPage = request.PageNumber > 1 ? request.PageNumber - 1 : null,
                Data = result
            };
        }

        public RoleDTO FindRoleById(int id)
        {
            var data = db.AddRole.Find(id);
            var res = mapper.Map<RoleDTO>(data);
            return res;
        }



        public bool UpdateRole(RoleUpdateDTO dto)
        {
            var data = db.AddRole.Find(dto.RoleId);

            if (data == null)
                return false;

            mapper.Map(dto, data); 

            db.SaveChanges();

            return true;
        }
    }
}
