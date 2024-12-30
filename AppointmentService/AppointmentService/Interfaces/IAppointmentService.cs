using AppointmentService.Models;
using AppointmentService.Models.DTO;

namespace AppointmentService.Interfaces
{
    public interface IAppointmentService
    {
        public Task<AppointmentDTO> CreateAppointment(AppointmentDTO dto,string token);
        public Task<UpdateDTO> UpdateAppointment(int id,UpdateDTO updateDTO,string token);
        public Task<Appointment> DeleteAppointment(int id);
    }
}
