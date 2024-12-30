using AutoMapper;
using Newtonsoft.Json.Linq;
using PatientRecordService.Interfaces;
using PatientRecordService.Models;
using PatientRecordService.Models.DTO;

namespace PatientRecordService.Services
{
    public class LabReportService : ILabReportService
    {
        private readonly IRepository<int,LabReport> _repository;
        private readonly IUserManagementService _userManagementService;
        private readonly IMapper _mapper;
        public LabReportService(IRepository<int, LabReport> repository,IUserManagementService userManagementService,IMapper mapper)
        {
            _repository = repository;
            _userManagementService = userManagementService;
            _mapper = mapper;   
        }
        public async Task<LabReportDTO> AddLabReport(LabReportDTO labReportDTO,string token)
        {
            var patient = await _userManagementService.GetPatientById(labReportDTO.PatientId, token);
            if (patient == null)
            {
                throw new Exception("patient not found");
            }

            var labReport = _mapper.Map<LabReport>(labReportDTO);
            var labReportAdd = await _repository.Add(labReport);
            return _mapper.Map<LabReportDTO>(labReportAdd);
        }

        public async Task<ICollection<LabReport>> GetLabReport(int patientId)
        {
            var lab = await _repository.Find(s => s.PatientId == patientId);
            return _mapper.Map<ICollection<LabReport>>(lab);
        }
    }
}
