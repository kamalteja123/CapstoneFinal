using AutoMapper;
using DoctorService.Models;
using DoctorService.Models.DTO;

namespace DoctorService.Mapper
{
    public class ScheduleProfile:Profile
    {
        public ScheduleProfile()
        {
            
            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<Schedule, UpdateAvailabilityDTO>().ReverseMap();
          
        }
    }
}
