using DDDHrmsWebApi.Application.Common;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDHrmsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskBoardController : ControllerBase
    {
        ITaskBoardService service;
        public TaskBoardController(ITaskBoardService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("AddTaskBoard")]
        public IActionResult AddTaskBoard(TaskBoardDTOSave e)
        {
            service.AddTaskBoard(e);

            return Ok(ApiResponse<object>
                .SuccessResponse(e, "TaskBoard Added Successfully"));
        }
        [HttpGet]
        [Route("FetchTaskBoard")]
        public IActionResult FetchTaskBoard()
        {
            var data = service.FetchTaskBoard();

            return Ok(ApiResponse<object>
                .SuccessResponse(data, "TaskBoard Fetched Successfully"));
        }
    }
}
