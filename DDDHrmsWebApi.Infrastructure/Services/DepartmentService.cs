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

      
        public List<DepartmentDTO> FetchDepartment()
        {
          var data = db.AddDepartments.ToList();
            var res = mapper.Map<List<DepartmentDTO>>(data);
            return res;
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

            db.AddDepartments.Remove(data);
            db.SaveChanges();

            return true;
        }

      
    }
}
