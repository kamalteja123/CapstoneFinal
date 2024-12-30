using AutoMapper;
using AppointmentService.Models;
using AppointmentService.Models.DTO;

namespace AppointmentService.Mapper
{
    public class AppointmentProfile:Profile
    {
        public AppointmentProfile()
        {
            
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<UpdateDTO, Appointment>().ReverseMap();
            
          
        }
    }
}
