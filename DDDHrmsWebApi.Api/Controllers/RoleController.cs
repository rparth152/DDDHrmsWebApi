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

        public RoleController(IRole role)
        {
            service = role;
        }

        [HttpPost]
        [Route("AddRole")]
        public IActionResult AddDepartment(RoleDTO dto)
        {
            service.AddRole(dto);
            return Ok(new { message = "Role Added  successfully", data = dto });
        }

        [HttpGet]
        [Route("FetchRole")]
        public IActionResult FetchRole()
        {
            var res = service.FetchRole();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetDeptByID/{id}")]
        public IActionResult FindRoleById(int id)
        {
            var data = service.FindRoleById(id);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdDepartment")]
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
