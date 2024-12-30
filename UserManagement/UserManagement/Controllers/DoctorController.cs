using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Filters;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Models.DTO;
using UserManagement.Services;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomExceptionFilter]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpPost]
        [Authorize(Roles ="Doctor")] 
        public async Task<ActionResult<DoctorProfileDTO>>CreateDoctorProfile(DoctorProfileDTO doctorProfileDto)
        {
            var userId = int.Parse(User.FindFirstValue("UserId"));
            var createdProfile = await _doctorService.CreateDoctorProfile(doctorProfileDto, userId);
            return createdProfile;
        }
        [HttpGet("ById")]
        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult<Doctor>> GetDoctorById(int id)
        {
            var doctor= await _doctorService.GetDoctor(id);
            return Ok(doctor);  
        }
    }
}
