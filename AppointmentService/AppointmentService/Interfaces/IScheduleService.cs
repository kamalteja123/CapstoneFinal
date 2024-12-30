using AppointmentService.Models.DTO;

namespace AppointmentService.Interfaces
{
    public interface IScheduleService
    {
        public Task<ICollection<ScheduleDTO>> GetSchedulesByDoctorId(int doctorId, string token);
        public Task<ICollection<ScheduleDTO>> GetSchedulesByDoctorIdAndDate(int doctorId, DateTime date, string token);
    }
}
