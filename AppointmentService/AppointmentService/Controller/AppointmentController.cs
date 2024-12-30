using AppointmentService.Filters;
using AppointmentService.Interfaces;
using AppointmentService.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentService.Controller
{
    [Route("api/appointments")]
    [ApiController]
    [CustomExceptionFilter]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpPost]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<AppointmentDTO>> ScheduleAppointment(AppointmentDTO dto, [FromHeader] string authorization)
        {
            var token = authorization?.Replace("Bearer ", "");
            var appointment = await _appointmentService.CreateAppointment(dto, token);
            return Ok(appointment);
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<AppointmentDTO>> CancleAppointment(int id)
        {
            var cancle = await _appointmentService.DeleteAppointment(id);
            return Ok(cancle);
        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<UpdateDTO>> ResheduleAppointment(int id, UpdateDTO updateDTO, [FromHeader] string authorization)
        {
            var token = authorization?.Replace("Bearer ", "");
            var reschedule = await _appointmentService.UpdateAppointment(id, updateDTO, token);
            return Ok(reschedule);
        }
    }
}
