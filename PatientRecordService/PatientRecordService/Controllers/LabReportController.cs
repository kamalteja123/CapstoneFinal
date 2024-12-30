using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientRecordService.Interfaces;
using PatientRecordService.Models;
using PatientRecordService.Models.DTO;

namespace PatientRecordService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabReportController : ControllerBase
    {
        private readonly ILabReportService _labReportService;
        public LabReportController(ILabReportService labReportService)
        {
             _labReportService = labReportService;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<LabReportDTO>> AddLabReport(LabReportDTO labReportDTO, [FromHeader] string authorization)
        {
            var token = authorization?.Replace("Bearer ", "");
            var labReport= await _labReportService.AddLabReport(labReportDTO, token);
            return Ok(labReport);   
        }
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<ActionResult<LabReport>> GetLabReport(int id)
        {
            var labReport=await _labReportService.GetLabReport(id);
            return Ok(labReport);
        }
    }
}
