using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DDDHrmsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignation service;

        public DesignationController(IDesignation designation)
        {
            service = designation;
        }

  
        [HttpPost]
        [Route("AddDesignation")]
        public IActionResult AddDesgination(DesignationDTO dto)
        {
            service.AddDesignation(dto);

            return Ok(ApiResponse<DesignationDTO>
                .SuccessResponse(dto, "Designation Added Successfully"));
        }


        [HttpGet]
        [Route("FetchDesignation")]
        public IActionResult FetchDesignation([FromQuery] PagedRequest request)
        {
            var res = service.FetchDesignation(request);

            return Ok(ApiResponse<PagedResponse<DesignationDeptDTO>>
                .SuccessResponse(res, "Designations fetched successfully"));
        }


        [HttpGet]
        [Route("GetDesignationByID/{id}")]
        public IActionResult FindDesignationById(int id)
        {
            var data = service.FindDesignationById(id);

            if (data == null)
            {
                return NotFound(ApiResponse<string>
                    .ErrorResponse("Designation not found"));
            }

            return Ok(ApiResponse<DesignationDTO>
                .SuccessResponse(data, "Designation found"));
        }

       
        [HttpPut]
        [Route("UpdateDesignation")]
        public IActionResult UpdateDesingation(DesignationDTO dto)
        {
            service.UpdateDesignation(dto);

            return Ok(ApiResponse<DesignationDTO>
                .SuccessResponse(dto, "Designation Updated Successfully"));
        }

     
        [HttpDelete("{id}")]
        public IActionResult DeleteDesignation(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ApiResponse<string>
                    .ErrorResponse("Invalid ID " + id ));
            }

            var result = service.DeleteDesignation(id);

            if (!result)
            {
                return NotFound(ApiResponse<string>
                    .ErrorResponse("Designation not found"));
            }

            return Ok(ApiResponse<string>
                .SuccessResponse(null, "Designation Deleted Successfully"));
        }
    }
}