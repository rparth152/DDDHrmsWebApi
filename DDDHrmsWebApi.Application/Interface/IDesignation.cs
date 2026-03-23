using DDDHrmsWebApi.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.Interface
{
    public interface IDesignation
    {
        void AddDesignation(DesignationDTO dto);

        List<DesignationDeptDTO> FetchDesignation();

        DesignationDTO FindDesignationById(int id);
        void UpdateDesignation(DesignationDTO dto);

        bool DeleteDesignation(int id);
    }
}
