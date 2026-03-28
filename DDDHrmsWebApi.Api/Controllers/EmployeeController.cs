using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDHrmsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployee service;

        public EmployeeController(IEmployee emp)
        {
            service = emp;
        }

        // Only Admin can access
        [Authorize(Roles = "Admin")]
        [HttpGet("admin-data")]
        public IActionResult AdminData()
        {
            return Ok("Only Admin Access");
        }

        //  Admin + Manager
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet("manager-data")]
        public IActionResult ManagerData()
        {
            return Ok("Manager + Admin Access");
        }

        // All logged-in users
        [Authorize]
        [HttpGet("all")]
        public IActionResult AllUsers()
        {
            return Ok("All authenticated users");
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(EmployeeDTO dto)
        {
            service.AddEmployee(dto);
            return Ok(new { message = "Employee Added  successfully", data = dto });
        }

        [HttpGet]
        [Route("FetchEmployee")]
        public IActionResult FetchEmployee()
        {
            var res = service.FetchEmployee();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetEmployeeByID/{id}")]
        public IActionResult FindEmployeeById(int id)
        {
            var data = service.FindEmployeeById(id);
            return Ok(data);
        }


        [HttpPut]
        [Route("UpdateDesignation")]
        public IActionResult UpdateEmployee(EmployeeDTO dto)
        {
            service.UpdateEmployee(dto);
            return Ok(new { message = "Designation Updated", data = dto });

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var result = service.DeleteEmployee(id);

            if (!result)
                return NotFound("Delete not found");

            return NoContent();
        }
    }
}
