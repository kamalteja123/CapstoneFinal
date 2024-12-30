using PatientRecordService.Models;
using PatientRecordService.Models.DTO;

namespace PatientRecordService.Interfaces
{
    public interface IMedicalHistoryService
    {
        public Task<ICollection<MedicalHistory>> GetMedicalHistoryByPatientId(int patientId);
        public Task<MedicalHistoryDTO> AddMedicalHistory(MedicalHistoryDTO medicalHistorydto,string token);

    }
}
