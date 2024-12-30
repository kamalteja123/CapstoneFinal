using AutoMapper;
using UserManagement.Models;
using UserManagement.Models.DTO;

namespace UserManagement.Mapper
{
    public class PatientProfile:Profile
    {
        public PatientProfile()
        {
            //CreateMap<Patient, PatientProfileDTO>()
            //    .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.PatientName))
            //    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
            //    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            //    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender)).ReverseMap();
            CreateMap<Patient, PatientProfileDTO>().ReverseMap();
            CreateMap<Doctor, DoctorProfileDTO>().ReverseMap();
            //CreateMap<Doctor, DoctorProfileDTO>()
            //   .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.DoctorName))
            //   .ForMember(dest => dest.Qualifications, opt => opt.MapFrom(src => src.Qualifications))
            //   .ForMember(dest => dest.YearsOfExperience, opt => opt.MapFrom(src => src.YearsOfExperience))
            //   .ForMember(dest => dest.Qualifications, opt => opt.MapFrom(src => src.Qualifications)).ReverseMap();
        }
    }
}
