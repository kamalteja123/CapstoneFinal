using PatientRecordService.Models.DTO;

namespace PatientRecordService.Interfaces
{
    public interface IUserManagementService
    {
       public Task<PatientProfileDTO> GetPatientById(int patientId, string token);
    }
}
