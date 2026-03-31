using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDHrmsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DepartmentController : ControllerBase
    {
        private readonly IDepartments service;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartments departments)
        {
            service = departments;
        }

       
        [HttpPost]
        [Route("AddDepartment")]
        public IActionResult AddDepartment(DepartmentDTO dto)
        {
            service.AddDepartment(dto);

            return Ok(ApiResponse<DepartmentDTO>
                .SuccessResponse(dto, "Department Added Successfully"));
        }

        
        [HttpGet]
        [Route("FetchDepartment")]
        public IActionResult FetchDepartment([FromQuery] PagedRequest request)
        {
            var res = service.FetchDepartment(request);

            return Ok(ApiResponse<PagedResponse<DepartmentDTO>>
                .SuccessResponse(res, "Departments fetched successfully"));
        }


        [HttpGet]
        [Route("GetDeptByID/{id}")]
        public IActionResult FindDeptById(int id)
        {
            var data = service.FindDeptById(id);

            if (data == null)
            {
                _logger.LogWarning("Department not found for ID: {Id}", id);

                return NotFound(ApiResponse<string>
                    .ErrorResponse("Department not found"));
            }

            return Ok(ApiResponse<DepartmentDTO>
                .SuccessResponse(data, "Department found"));
        }


        [HttpPut]
        [Route("UpdDepartment")]
        public IActionResult UpdateDeptment(DepartmentDTO dto)
        {
            service.UpdateDeptment(dto);

            return Ok(ApiResponse<DepartmentDTO>
                .SuccessResponse(dto, "Department Updated Successfully"));
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ApiResponse<string>
                    .ErrorResponse("Invalid ID"));
            }

            var result = service.DeleteDepartment(id);

            if (!result)
            {
                return NotFound(ApiResponse<string>
                    .ErrorResponse("Department not found"));
            }

            return Ok(ApiResponse<string>
                .SuccessResponse(null, "Department Deleted Successfully"));
        }
    }
}