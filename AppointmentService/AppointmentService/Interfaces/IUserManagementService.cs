using AppointmentService.Models.DTO;

namespace AppointmentService.Interfaces
{
    public interface IUserManagementService
    {
        public Task<PatientDTO> GetPatient(int patientId,string token);
    }
}
