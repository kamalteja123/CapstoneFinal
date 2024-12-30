using UserManagement.Models;
using UserManagement.Models.DTO;

namespace UserManagement.Interfaces
{
    public interface IPatientService
    {
        Task<PatientProfileDTO> CreatePatientProfile(PatientProfileDTO patientProfileDTO,int UserId);
        public Task<Patient> GetPatient(int id);
    }
}
