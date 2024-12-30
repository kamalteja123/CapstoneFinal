using System.Numerics;
using AutoMapper;
using DoctorService.Interfaces;
using DoctorService.Models;
using DoctorService.Models.DTO;
using DoctorService.Repositories;
using Newtonsoft.Json.Linq;

namespace DoctorService.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<int,Schedule> _scheduleRepository; 
        private readonly IUserManagementService _userManagementService;
        private readonly IMapper _mapper;
        public ScheduleService(IRepository<int, Schedule> scheduleRepository, IUserManagementService userManagementService,IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _userManagementService = userManagementService;
            _mapper = mapper;
        }
        public async Task<ScheduleDTO> CreateSchedule(ScheduleDTO scheduleDto, string token)
        {
            var doctor = await _userManagementService.GetDoctorById(scheduleDto.DoctorId, token);
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }
             var schedule = _mapper.Map<Schedule>(scheduleDto);
            var scheduleAdd=await _scheduleRepository.Add(schedule); 
            return _mapper.Map<ScheduleDTO>(scheduleAdd);
        }

        public async Task<ICollection<ScheduleDTO>> GetAllSchedule()
        {
            var schedules = await _scheduleRepository.GetAll();
            var availableSchedules = schedules.Where(s => s.IsAvailable).ToList(); 
            return _mapper.Map<ICollection<ScheduleDTO>>(availableSchedules);
        }

        public async Task<ICollection<ScheduleDTO>> GetSchedulesByDoctorId(int doctorId)
        {
            var schedules = await _scheduleRepository.Find(s => s.DoctorId == doctorId && s.IsAvailable);
            return _mapper.Map<ICollection<ScheduleDTO>>(schedules);
        }

        public async Task<UpdateAvailabilityDTO> UpdateSchedule(UpdateAvailabilityDTO updateAvailabilityDTO,int id)
        {
            var doctorupdate = await _scheduleRepository.Get(id);
            if (doctorupdate == null) 
            { 
                throw new Exception("No schedule is their"); 
            }
            _mapper.Map(updateAvailabilityDTO, doctorupdate);
            await _scheduleRepository.Update(id,doctorupdate);
            return updateAvailabilityDTO;
        }
    }
}
