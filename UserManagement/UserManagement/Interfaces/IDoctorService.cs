using UserManagement.Models;
using UserManagement.Models.DTO;

namespace UserManagement.Interfaces
{
    public interface IDoctorService
    {
        public Task<DoctorProfileDTO> CreateDoctorProfile(DoctorProfileDTO doctorProfileDTO, int UserId);
        public Task<Doctor> GetDoctor(int id);
    }
}
