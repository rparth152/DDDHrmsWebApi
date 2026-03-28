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
        public void AddEmployee(EmployeeDTO dto)
        {
            var emp = mapper.Map<Employee>(dto);
            db.Employee.Add(emp);
            db.SaveChanges();
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

        public List<EmpDeptDesigRole> FetchEmployee()
        {
            var data = db.Employee.Include(x => x.AddDepartments)
                .Include(x => x.AddRole).Include(x => x.AddDesignation).ToList();

            var res = mapper.Map<List<EmpDeptDesigRole>>(data); 

            return res;
        }

        public EmployeeDTO FindEmployeeById(int id)
        {
            var data = db.Employee.Find(id);
            var res = mapper.Map<EmployeeDTO>(data);
            return res;
        }

        public void UpdateEmployee(EmployeeDTO dto)
        {
            var e = mapper.Map<Employee>(dto);
            db.Employee.Update(e);
            db.SaveChanges();
        }
    }
}
