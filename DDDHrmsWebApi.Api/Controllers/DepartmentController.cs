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
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(IDepartments departments, ILogger<DepartmentController> logger)
        {
            service = departments;
            _logger = logger;
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
            _logger.LogInformation("Get Departments API called");
            try
            {
                var res = service.FetchDepartment();
                _logger.LogInformation("Departments fetched successfully");
                return Ok(res);
            }
            catch (Exception ex) {

                _logger.LogError(ex, "Error in Get Departments");
                return StatusCode(500, "Internal Server Error");

            }
          
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
