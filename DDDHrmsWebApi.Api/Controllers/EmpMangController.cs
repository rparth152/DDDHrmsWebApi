using DDDHrmsWebApi.Application.Common;
using DDDHrmsWebApi.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDHrmsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpMangController : ControllerBase
    {
            IProjectEmp empService;
            IProjectMang mangService;

            public EmpMangController(IProjectEmp empService, IProjectMang mangService)
            {
                this.empService = empService;
                this.mangService = mangService;
            }

            [HttpGet]
            [Route("Employees")]
            public IActionResult FetchEmp()
            {
                var data = empService.FetchEmp();

                return Ok(ApiResponse<object>
                    .SuccessResponse(data, "Employees Fetched Successfully"));
            }

            [HttpGet]
            [Route("Managers")]
            public IActionResult FetchManager()
            {
                var data = mangService.FetchManager();

                return Ok(ApiResponse<object>
                    .SuccessResponse(data, "Managers Fetched Successfully"));
            }
        }
    }