using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DDDHrmsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {   
        IDepartments service;
        public DepartmentController(IDepartments departments)
        {
            service = departments;
        }

        [HttpPost]
        [Route("AddDepartment")]
        public IActionResult AddDepartment(DepartmentDTO dto)
        {
            service.AddDepartment(dto);
            return Ok(new { message = "Department Added  successfully", data = dto });
        }

        [HttpGet]
        [Route("FetchDepartment")]
        public IActionResult FetchDepartment()
        {
            var res = service.FetchDepartment();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetDeptByID/{id}")]
        public IActionResult FindDeptById(int id) { 
            var data = service.FindDeptById(id);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdDepartment")]
        public IActionResult UpdateDeptment(DepartmentDTO dto)
        {
            service.UpdateDeptment(dto);
            return Ok(new {message="Department Updated", data = dto });

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var result = service.DeleteDepartment(id);

            if (!result)
                return NotFound("Department not found");

            return NoContent(); 
        }

        
    }
}
