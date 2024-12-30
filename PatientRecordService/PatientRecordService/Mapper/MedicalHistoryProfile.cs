using AutoMapper;
using PatientRecordService.Models;
using PatientRecordService.Models.DTO;

namespace PatientRecordService.Mapper
{
    public class MedicalHistoryProfile:Profile
    {
        public MedicalHistoryProfile()
        {          
            CreateMap<MedicalHistory, MedicalHistoryDTO>().ReverseMap();
            CreateMap<LabReport, LabReportDTO>().ReverseMap();
        }
    }
}
