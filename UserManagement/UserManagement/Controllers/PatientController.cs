using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Filters;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Models.DTO;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomExceptionFilter]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService=patientService;
        }
        [HttpPost]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<PatientProfileDTO>> CreatePatient(PatientProfileDTO patientProfileDTO)
        {
            var userId = int.Parse(User.FindFirstValue("UserId"));
            var createdProfile = await _patientService.CreatePatientProfile(patientProfileDTO, userId);
             return createdProfile;
        }
        [HttpGet("ById")]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<Patient>> GetpatientById(int id)
        {
            var patient =await _patientService.GetPatient(id);
            return Ok(patient); 
        }
    }
}
