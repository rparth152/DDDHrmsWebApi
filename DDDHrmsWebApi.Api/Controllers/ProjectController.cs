using DDDHrmsWebApi.Application.Common;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDHrmsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IProjectService service;
        public ProjectController(IProjectService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("AddProject")]
        public IActionResult AddProject(ProjectDTOSave e)
        {
            service.AddProject(e);

            return Ok(ApiResponse<object>
                .SuccessResponse(e, "Project Added Successfully"));
        }
        [HttpGet]
        [Route("FetchProject")]
        public IActionResult FetchProject()
        {
            var data = service.FetchProject();

            return Ok(ApiResponse<object>
                .SuccessResponse(data, "Project Fetched Successfully"));
        }
    }
}
