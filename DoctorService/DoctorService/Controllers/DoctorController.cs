using DoctorService.Interfaces;
using DoctorService.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DoctorService.Filters;
using DoctorService.Models;
using Microsoft.AspNetCore.Authorization;

namespace DoctorService.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    [CustomExceptionFilter]
    public class DoctorController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        public DoctorController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [HttpGet("{doctorId:int}")]
        [Authorize]
        public async Task<ActionResult<ICollection<ScheduleDTO>>> GetSchedules(int doctorId)
        {
            var schedules = await _scheduleService.GetSchedulesByDoctorId(doctorId);
            return Ok(schedules);
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult<ScheduleDTO>> CreateSchedule([FromBody] ScheduleDTO scheduleDto, [FromHeader] string authorization)
        {
            var token = authorization?.Replace("Bearer ", "");
            var createdSchedule = await _scheduleService.CreateSchedule(scheduleDto, token);
            return Ok(createdSchedule);
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ICollection<Schedule>>> GetAllSchedules()
        {
            var schedules = await _scheduleService.GetAllSchedule();
            schedules = schedules.ToList();
            return Ok(schedules);
        }

        [HttpPut("{id:int}/availability")]
        [Authorize(Roles = "Doctor")]
        public async Task<ActionResult<UpdateAvailabilityDTO>> UpdateAvailability(int id,UpdateAvailabilityDTO updateAvailabilityDTO)
        {
           
            var doctorSchedule = await _scheduleService.UpdateSchedule(updateAvailabilityDTO,id);
            return Ok(doctorSchedule);
        }
    }
}
