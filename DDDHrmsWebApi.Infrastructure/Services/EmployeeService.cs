using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Domain.Model;
using DDDHrmsWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Infrastructure.Services
{
    public class EmployeeService : IEmployee
    {
        ApplicationDbContext db;
        IMapper mapper;
        public EmployeeService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        //public void AddEmployee(EmployeeDTO dto)
        //{
        //    var emp = mapper.Map<Employee>(dto);
        //    db.Employee.Add(emp);
        //    db.SaveChanges();
        //}

        public async Task AddEmployee(EmployeeDTO dto)
        {
            string? imagePath = null;

            if (dto.ImageFile != null)
            {
                var folderPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Images"
                );

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = Guid.NewGuid().ToString() +
                               Path.GetExtension(dto.ImageFile.FileName);

                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream);
                }

                imagePath = "/Images/" + fileName;
            }

          
            var emp = mapper.Map<Employee>(dto);

          
            emp.ImagePath = imagePath;

            db.Employee.Add(emp);
            await db.SaveChangesAsync();
        }

        

        //public List<EmpDeptDesigRole> FetchEmployee()
        //{
        //    var data = db.Employee.Include(x => x.AddDepartments)
        //        .Include(x => x.AddRole).Include(x => x.AddDesignation).ToList();

        //    var res = mapper.Map<List<EmpDeptDesigRole>>(data); 

        //    return res;
        //}

        public PagedResponse<EmpDeptDesigRole> FetchEmployee(PagedRequest request)
        {
            var query = db.Employee
                .Include(x => x.AddDepartments)
                .Include(x => x.AddRole)
                .Include(x => x.AddDesignation)
                .AsQueryable();

            //  Search + Filter
            query = query.Where(x =>
                (string.IsNullOrWhiteSpace(request.SearchText) ||
                    (
                        (x.FirstName != null && x.FirstName.ToLower().Contains(request.SearchText.Trim().ToLower()))
                        ||
                        (x.LastName != null && x.LastName.ToLower().Contains(request.SearchText.Trim().ToLower()))
                        ||
                        (x.Email != null && x.Email.ToLower().Contains(request.SearchText.Trim().ToLower()))
                    ))
                &&
                (string.IsNullOrWhiteSpace(request.Status) ||
                    (x.Status != null && x.Status.ToLower() == request.Status.Trim().ToLower()))
            );

            //  Sorting
            if (!string.IsNullOrEmpty(request.SortBy))
            {
                var sortOrder = request.SortOrder?.ToLower() == "desc"
                    ? "descending"
                    : "ascending";

                if (request.SortBy == "FirstName" ||
                    request.SortBy == "Email" ||
                    request.SortBy == "Status")
                {
                    query = query.OrderBy($"{request.SortBy} {sortOrder}");
                }
                else
                {
                    query = query.OrderBy("FirstName ascending");
                }
            }
            else
            {
                query = query.OrderBy("FirstName ascending");
            }

            //  Count before paging
            var totalRecords = query.Count();

            var totalPages = (int)Math.Ceiling(
                (double)totalRecords / request.PageSize
            );

            // Pagination
            var data = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            //  Mapping
            var result = mapper.Map<List<EmpDeptDesigRole>>(data);

            //  Final response
            return new PagedResponse<EmpDeptDesigRole>
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

        public EmployeeDTO FindEmployeeById(int id)
        {
            var data = db.Employee.Find(id);
            var res = mapper.Map<EmployeeDTO>(data);
            return res;
        }

        public async Task UpdateEmployee(EmployeeDTO dto)
        {
            var e = db.Employee.FirstOrDefault(x => x.EmployeeId == dto.EmployeeId);

            if (e == null)
                throw new Exception("Employee not found");

            // map all normal fields
            mapper.Map(dto, e);

            // update image only if new file uploaded
            if (dto.ImageFile != null)
            {
                var folderPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "Images"
                );

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // declare fileName here
                var fileName = Guid.NewGuid().ToString() +
                               Path.GetExtension(dto.ImageFile.FileName);

                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream);
                }

                // save image path
                e.ImagePath = "/Images/" + fileName;
            }

            await db.SaveChangesAsync();
        }


        public bool DeleteEmployee(int id)
        {
            var data = db.Employee.Find(id);

            if (data == null)
            {

                return false;
            }

            db.Employee.Remove(data);
            db.SaveChanges();

            return true;
        }
    }
}
