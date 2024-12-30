using DoctorService.Models.DTO;

namespace DoctorService.Interfaces
{
    public interface IUserManagementService 
    { 
        Task<DoctorDTO> GetDoctorById(int doctorId, string token); 
    }
}
