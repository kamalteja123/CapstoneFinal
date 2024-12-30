using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Models.DTO;

namespace UserManagement.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<int, Patient> _repository;
        private readonly IMapper _mapper;
        public PatientService(IRepository<int, Patient> repository,IMapper mapper)
        {
            _repository = repository;   
            _mapper = mapper;   
        }

        public async Task<PatientProfileDTO> CreatePatientProfile(PatientProfileDTO patientProfileDTO,int UserId)
        {

            var patient = _mapper.Map<Patient>(patientProfileDTO);
            patient.UId = UserId;
            var addPatient = await  _repository.Add(patient);
            return  _mapper.Map<PatientProfileDTO>(addPatient);
        }

        public async Task<Patient> GetPatient(int id)
        {
            var patient1 = await _repository.Get(id);
            return patient1;
        }
    }
}
