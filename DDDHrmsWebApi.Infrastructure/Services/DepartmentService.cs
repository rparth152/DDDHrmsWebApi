using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Domain.Model;
using DDDHrmsWebApi.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace DDDHrmsWebApi.Infrastructure.Services
{
    public class DepartmentService : IDepartments
    {
        ApplicationDbContext db;
        IMapper mapper;
        public DepartmentService(ApplicationDbContext db, IMapper mapper) { 
            this.db = db;
            this.mapper = mapper;
        }
        public void AddDepartment(DepartmentDTO dto)
        {
          var dept =  mapper.Map<AddDepartments>(dto);
            db.AddDepartments.Add(dept);
            db.SaveChanges();
        }


        //public List<DepartmentDTO> FetchDepartment()
        //{
        //  var data = db.AddDepartments.ToList();
        //    var res = mapper.Map<List<DepartmentDTO>>(data);
        //    return res;
        //}

        public PagedResponse<DepartmentDTO> FetchDepartment(PagedRequest request)
        {
            var query = db.AddDepartments.AsQueryable();

          query = query.Where(x => (string.IsNullOrWhiteSpace(request.SearchText) ||
         (x.DepartmentName != null && x.DepartmentName.ToLower().Contains(request.SearchText.Trim().ToLower())))
            &&
         (string.IsNullOrWhiteSpace(request.Status) || (x.Status != null && x.Status.ToLower() == request.Status.Trim().ToLower())));

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                var sortOrder = request.SortOrder?.ToLower() == "desc" ? "descending" : "ascending";

                if (request.SortBy == "DepartmentName" || request.SortBy == "Status")
                {
                    query = query.OrderBy($"{request.SortBy} {sortOrder}");
                }
                else
                {
                    query = query.OrderBy("DepartmentName ascending");
                }
            }
            else
            {
                query = query.OrderBy("DepartmentName ascending");
            }

            var totalRecords = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / request.PageSize);

            var data = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var result = mapper.Map<List<DepartmentDTO>>(data);

            return new PagedResponse<DepartmentDTO>
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
        public DepartmentDTO FindDeptById(int id)
        {
            var data = db.AddDepartments.Find(id);
            var res =  mapper.Map<DepartmentDTO>(data);
            return res;
        }

        public void UpdateDeptment(DepartmentDTO dto)
        {
            var  e = mapper.Map<AddDepartments>(dto);
            db.AddDepartments.Update(e);
            db.SaveChanges();


        }

        [HttpDelete("{id}")]
        public bool DeleteDepartment(int id)
        {
            var data = db.AddDepartments.Find(id);

            if (data == null)
            {
               
                return false ; 
            }

            data.Status = "Inactive";
            db.AddDepartments.Remove(data);
            db.SaveChanges();

            return true;
        }

      
    }
}
