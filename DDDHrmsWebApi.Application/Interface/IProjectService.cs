using DDDHrmsWebApi.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.Interface
{
    public interface IProjectService
    {
        void AddProject(ProjectDTOSave Pdto);
        List<ProjectDTOFetch> FetchProject();
    }
}
