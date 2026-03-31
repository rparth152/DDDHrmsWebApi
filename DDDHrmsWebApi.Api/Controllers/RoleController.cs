using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDHrmsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRole service;
        private readonly ILogger<DepartmentController> _logger;

        public RoleController(IRole role)
        {
            service = role;
        }

        [HttpPost]
        [Route("AddRole")]
        public IActionResult AddDepartment(RoleDTO dto)
        {
            service.AddRole(dto);
            //return Ok(new { message = "Role Added  successfully", data = dto });

            return Ok(ApiResponse<RoleDTO>.SuccessResponse(dto, "Role Added Successfully"));
        }

        [HttpGet]
        [Route("FetchRole")]
        public IActionResult FetchRole([FromQuery] PagedRequest request)
        {
            var res = service.FetchRole(request);
            return Ok(ApiResponse<PagedResponse<RoleDTO>>.SuccessResponse(res, "Role fetched successfully"));
        }

        [HttpGet]
        [Route("GetDeptByID/{id}")]
        public IActionResult FindRoleById(int id)
        {
            var data = service.FindRoleById(id);
            //return Ok(data);


            if (data == null)
            {
                //_logger.LogWarning("Department not found for ID: {Id}", id);

                return NotFound(ApiResponse<string>.ErrorResponse("Department not found"));
            }

            return Ok(ApiResponse<RoleDTO>.SuccessResponse(data, "Department found"));
        }

        [HttpPut]
        [Route("UpdateRole")]
        public IActionResult UpdateRole(RoleUpdateDTO dto)
        {
            service.UpdateRole(dto);
            return Ok(new { message = "Role Updated", data = dto });

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var result = service.DeleteRole(id);

            if (!result)
                return NotFound("Role not found");

            return NoContent();
        }


    }
}
