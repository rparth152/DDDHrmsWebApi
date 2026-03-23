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

        public List<DesignationDeptDTO> FetchDesignation()
        {
            var data = db.AddDesignation.Include(x => x.AddDepartments) .ToList();

            var res = mapper.Map<List<DesignationDeptDTO>>(data);
            return res;
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
