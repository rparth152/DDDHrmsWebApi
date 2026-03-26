using AutoMapper;
using DDDHrmsWebApi.Application.DTO;
using DDDHrmsWebApi.Application.Interface;
using DDDHrmsWebApi.Infrastructure.Data;
using DDDHrmsWebApi.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDHrmsWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        IMapper mapper;
        IEstatus service;
        public ReportsController(IEstatus service,IMapper mapper) {
            this.service = service;
            this.mapper = mapper;
        }
        [HttpGet ("empstatus")]
        public IActionResult Estatus() {
            var data=service.Fetchdata();
            return Ok(ApiResponse<EstatusDTO>.SuccessResponse(data));
        }
        [HttpGet("fetchemp")]
        public IActionResult FetchEmployees() {
            var data = service.Employees();
            return Ok(ApiResponse<List<FetchEmpDTO>>.SuccessResponse(data));
        }
        [HttpGet("fattendance")]
        public IActionResult FetchAttendance() {
            var data = service.FAttendance();
            return Ok(ApiResponse<List<FetchAttendance>>.SuccessResponse(data)); 
            //if (data != null)
            //{
            //    return Ok(ApiResponse<List<FetchAttendance>>.SuccessResponse(data));
            //}
            //else { return Ok(ApiResponse<List<FetchAttendance>>.ErrorResponse("Error Fetching the data")); }
        }
        [HttpGet("fleaves")]
        public IActionResult FetchLeaves() {
            var data = service.Leaves();
            return Ok(ApiResponse<List<FetchLeaves>>.SuccessResponse(data));
        }
        [HttpGet("ExportCSV")]
        [Produces("text/csv")]
        public IActionResult ExportCsv() {
            var data = service.ExportEmployeesToCSV();
            return File(data, "text/csv", "EmployeeReport.csv");
        }
        [HttpGet("ExportPDF")]
        public IActionResult ExportPdf()
        {
            var data = service.ExportEmployeesToPDF();
            return File(data, "application/pdf", "EmployeeReport.pdf");
        }
        //[HttpGet("Empcount")]
        //public IActionResult EmployeeCount() {
        //    var data = service.EmployeeCount();
        //    return Ok(data);
        //}
        //[HttpGet("ActiveEmp")]
        //public IActionResult ActiveEmployees() {
        //    var data = service.ActiveEmployees();
        //    return Ok(data);
        //}
        //[HttpGet("InactiveEmp")]
        //public IActionResult InactiveEmployees() {
        //    var data = service.InactiveEmployees();
        //    return Ok(data);
        //}
    }
}
