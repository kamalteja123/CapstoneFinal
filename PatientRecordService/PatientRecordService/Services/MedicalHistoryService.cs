using System.Numerics;
using AutoMapper;
using PatientRecordService.Interfaces;
using PatientRecordService.Models;
using PatientRecordService.Models.DTO;
using PatientRecordService.Repositories;

namespace PatientRecordService.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly IRepository<int,MedicalHistory> _repository;
        private readonly IUserManagementService _userManagementService;
        private readonly IMapper _mapper;
        public MedicalHistoryService(IRepository<int, MedicalHistory> repository, IUserManagementService userManagementService, IMapper mapper)
        {
            _repository = repository;
            _userManagementService=userManagementService;
            _mapper = mapper;
        }
        public async Task<MedicalHistoryDTO> AddMedicalHistory(MedicalHistoryDTO medicalHistorydto, string token)
        {
            var patient = await _userManagementService.GetPatientById(medicalHistorydto.PatientId, token);
            if (patient == null)
            {
                throw new Exception("patient not found");
            }
            
            var medicalReport = _mapper.Map<MedicalHistory>(medicalHistorydto); 
            var medicalReportAdd = await _repository.Add(medicalReport); 
            return _mapper.Map<MedicalHistoryDTO>(medicalReportAdd);
            
        }

        public async  Task<ICollection<MedicalHistory>> GetMedicalHistoryByPatientId(int patientId)
        {
            var medical = await _repository.Find(s => s.PatientId == patientId);
            return _mapper.Map<ICollection<MedicalHistory>>(medical);
        }
    }
}
