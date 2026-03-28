using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Domain.Model;
using DDDHrmsWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core; 

namespace DDDHrmsWebApi.Infrastructure.Services
{
    public class DesignationService : IDesignation
    {
        ApplicationDbContext db;
        IMapper mapper;
        public DesignationService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void AddDesignation(DesignationDTO dto)
        {
            var dept = mapper.Map<AddDesignation>(dto);
            db.AddDesignation.Add(dept);
            db.SaveChanges();
        }

        public bool DeleteDesignation(int id)
        {
            var data = db.AddDesignation.Find(id);

            if (data == null)
            {

                return false;
            }

            db.AddDesignation.Remove(data);
            db.SaveChanges();

            return true;
        }


        public PagedResponse<DesignationDeptDTO> FetchDesignation(PagedRequest request)
        {
            var query = db.AddDesignation
                .Include(x => x.AddDepartments)
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.SearchText))
            {
                var search = request.SearchText.ToLower();

                query = query.Where(x =>
                    x.DesignationName.ToLower().Contains(search) ||
                    x.Status.ToLower().Contains(search)
                );
            }

           
            if (!string.IsNullOrEmpty(request.Status))
            {
                query = query.Where(x => x.Status == request.Status);
            }

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                var sortOrder = request.SortOrder?.ToLower() == "desc" ? "descending" : "ascending";
                query = query.OrderBy($"{request.SortBy} {sortOrder}");
            }

            var totalRecords = query.Count();

            
            var totalPages = (int)Math.Ceiling((double)totalRecords / request.PageSize);

    
            var data = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var result = mapper.Map<List<DesignationDeptDTO>>(data);

            return new PagedResponse<DesignationDeptDTO>
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

        public DesignationDTO FindDesignationById(int id)
        {
            var data = db.AddDesignation.Find(id);
            var res = mapper.Map<DesignationDTO>(data);
            return res;
        }

        public void UpdateDesignation(DesignationDTO dto)
        {
            var e = mapper.Map<AddDesignation>(dto);
            db.AddDesignation.Update(e);
            db.SaveChanges();
        }
    }
}
