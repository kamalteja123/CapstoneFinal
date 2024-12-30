using AutoMapper;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Models.DTO;

namespace UserManagement.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _repository;
        private readonly IMapper _mapper;
        public DoctorService(IRepository<int, Doctor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DoctorProfileDTO> CreateDoctorProfile(DoctorProfileDTO doctorProfileDTO, int UserId)
        {
            var doctor = _mapper.Map<Doctor>(doctorProfileDTO);
            doctor.UId = UserId;
            var addDoctor = await _repository.Add(doctor);
            return _mapper.Map<DoctorProfileDTO>(addDoctor);
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            var doctor1=await _repository.Get(id);
            return doctor1;
        }
    }
}
