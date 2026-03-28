using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDHrmsWebApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // all methods require login
    public class DashboardController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult Admin()
        {
            return Ok("Admin Dashboard");
        }

        [Authorize(Roles = "Manager")]
        [HttpGet("manager")]
        public IActionResult Manager()
        {
            return Ok("Manager Dashboard");
        }

        [Authorize(Roles = "Employee")]
        [HttpGet("employee")]
        public IActionResult Employee()
        {
            return Ok("Employee Dashboard");
        }
    }
}
