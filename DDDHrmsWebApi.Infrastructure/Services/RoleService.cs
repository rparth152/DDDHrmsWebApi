using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Domain.Model;
using DDDHrmsWebApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<RoleDTO> FetchRole()
        {
            var data = db.AddRole.ToList();
            var res = mapper.Map<List<RoleDTO>>(data);
            return res;
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
