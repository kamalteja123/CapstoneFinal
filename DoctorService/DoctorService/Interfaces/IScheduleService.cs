using DoctorService.Models.DTO;

namespace DoctorService.Interfaces
{
    public interface IScheduleService
    {
       public  Task<ICollection<ScheduleDTO>> GetSchedulesByDoctorId(int doctorId);
        public Task<ICollection<ScheduleDTO>> GetAllSchedule();
        public Task<ScheduleDTO> CreateSchedule(ScheduleDTO scheduleDto, string token);
        public Task<UpdateAvailabilityDTO> UpdateSchedule(UpdateAvailabilityDTO updateAvailabilityDTO,int id);
    }
}
