using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDHrmsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        IDesignation service;

        public DesignationController(IDesignation designation)
        {
            service = designation;
        }

        [HttpPost]
        [Route("AddDesignation")]
        public IActionResult AddDesgination(DesignationDTO dto)
        {
            service.AddDesignation(dto);
            return Ok(new { message = "Designation Added  successfully", data = dto });
        }

        [HttpGet]
        [Route("FetchDesignation")]
        public IActionResult FetchDesignation()
        {
            var res = service.FetchDesignation();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetDesignationByID/{id}")]
        public IActionResult FindDesignationById(int id)
        {
            var data = service.FindDesignationById(id);
            return Ok(data);
        }


        [HttpPut]
        [Route("UpdateDesignation")]
        public IActionResult UpdateDesingation(DesignationDTO dto)
        {
            service.UpdateDesignation(dto);
            return Ok(new { message = "Designation Updated", data = dto });

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDesignation(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var result = service.DeleteDesignation(id);

            if (!result)
                return NotFound("Department not found");

            return NoContent();
        }
    }
}
