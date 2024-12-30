using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientRecordService.Filters;
using PatientRecordService.Interfaces;
using PatientRecordService.Models;
using PatientRecordService.Models.DTO;
namespace PatientRecordService.Controllers
{
    [Route("api/records")]
    [ApiController]
    [CustomExceptionFilter]
    public class MedicalReportController : ControllerBase
    {
        private readonly IMedicalHistoryService _historyService;
        public MedicalReportController(IMedicalHistoryService historyService)
        {
            _historyService = historyService;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<MedicalHistoryDTO>> AddMedicalReport(MedicalHistoryDTO medicalHistoryDTO, [FromHeader] string authorization)
        {
            var token = authorization?.Replace("Bearer ", "");
            var medicalReport = await _historyService.AddMedicalHistory(medicalHistoryDTO, token);
            return Ok(medicalReport);
          
        }
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<ActionResult<MedicalHistory>> GetMedicalReport(int id)
        {
            var patientReport= await _historyService.GetMedicalHistoryByPatientId(id);
            return Ok(patientReport);
        }
    }
}
