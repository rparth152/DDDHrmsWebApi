using DDDHrmsWebApi.Application.Common;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDHrmsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ITaskService service;
        public TaskController(ITaskService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("AddTask")]
        public IActionResult AddTask(TaskDTOSave e)
        {
            service.AddTask(e);

            return Ok(ApiResponse<object>
                .SuccessResponse(e, "Task Added Successfully"));

        }
        [HttpGet]
        [Route("FetchTask")]
        public IActionResult FetchTask()
        {
            var data = service.FetchTask();

            return Ok(ApiResponse<object>
                .SuccessResponse(data, "Task fetched Successfully"));
        }
    }
}
