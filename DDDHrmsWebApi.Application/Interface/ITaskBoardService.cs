using DDDHrmsWebApi.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDHrmsWebApi.Application.Interface
{
    public interface ITaskBoardService
    {
        void AddTaskBoard(TaskBoardDTOSave tbdto);
        List<TaskBoardDTOFetch> FetchTaskBoard();
    }
}
