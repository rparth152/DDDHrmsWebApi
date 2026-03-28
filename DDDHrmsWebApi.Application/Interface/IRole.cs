using DDDHrmsWebApi.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.Interface
{
    public interface IRole
    {
        void AddRole(RoleDTO dto);

        List<RoleDTO> FetchRole();

        RoleDTO FindRoleById(int id);
        bool UpdateRole(RoleUpdateDTO dto);

        bool DeleteRole(int id);
    }
}
