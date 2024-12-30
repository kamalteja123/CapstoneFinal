using PatientRecordService.Models;
using PatientRecordService.Models.DTO;

namespace PatientRecordService.Interfaces
{
    public interface ILabReportService
    {
        public Task<LabReportDTO> AddLabReport(LabReportDTO labReportDTO,string token);
        public Task<ICollection<LabReport>> GetLabReport(int patientId);
    }
}
