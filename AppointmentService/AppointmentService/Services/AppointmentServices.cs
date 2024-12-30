using AppointmentService.Interfaces;
using AppointmentService.Models;
using AppointmentService.Models.DTO;
using AutoMapper;

namespace AppointmentService.Services
{
    public class AppointmentServices : IAppointmentService
    {
        private readonly IScheduleService _scheduleService;
        private readonly IUserManagementService _userManagementService;
        private readonly IMapper _mapper;
        private readonly IRepository<int,Appointment> _repository; 
        private readonly IBillingService _billingService;
        public AppointmentServices(IUserManagementService userManagementService,IScheduleService scheduleService,IMapper mapper
                                    ,IRepository<int,Appointment> repository, IBillingService billingService)
        {
            _scheduleService = scheduleService;
            _userManagementService = userManagementService; 
            _mapper = mapper;
            _repository = repository;
            _billingService = billingService;
        }
        public async Task<AppointmentDTO> CreateAppointment(AppointmentDTO dto,string token)
        {

            var schedules = await _scheduleService.GetSchedulesByDoctorIdAndDate(dto.DoctorId, dto.AppointmentDate,token);
            if (schedules == null || schedules.Count == 0)
            {
                throw new Exception("No schedules found for the doctor on the specified date");
            }
            var isSlotAvailable = schedules.Any(s => s.IsAvailable && dto.StartTime >= s.StartTime && dto.EndTime <= s.EndTime);
            if (!isSlotAvailable)
            {
                throw new Exception("No available slot for the specified time");
            }
            var patient = await _userManagementService.GetPatient(dto.PatientId, token);
            if (patient == null)
            {
                throw new Exception("Patient not found");
            }
            var appointment=_mapper.Map<Appointment>(dto);
            var appointmentdto=await _repository.Add(appointment);
            var invoice = await GetInvoice(appointmentdto,token);

            return _mapper.Map<AppointmentDTO>(appointmentdto); 
        }

        private async Task<InvoiceDTO> GetInvoice(Appointment appointmentdto,string token)
        {
            var invoiceDto = new InvoiceDTO
            {
                AppointmentId = appointmentdto.AppointmentId,
                PatientId = appointmentdto.PatientId,
                Amount=500.0f,
                InvoiceDate=DateTime.Now,
                IsPaid=false,
                PaymentMethod="Debit Card"

            };
            var createdInvoice = await _billingService.CreateInvoice(invoiceDto,token);
            if (createdInvoice == null)
            {
                throw new Exception("Not added to billing service");
            }
            return createdInvoice;
        }


        public async Task<Appointment> DeleteAppointment(int id)
        {
           var appointment= await _repository.Get(id);
            if (appointment == null)
            {
                throw new Exception("NO appointment to delete");
            }
            await _repository.Delete(id);
            return appointment;
        }

        public async  Task<UpdateDTO> UpdateAppointment(int id, UpdateDTO updateDTO, string token)
        {
            var appointment = await _repository.Get(id);
            if(appointment == null)
            {
                throw new Exception("Their is no appointment to update");
            }
            var schedules = await _scheduleService.GetSchedulesByDoctorIdAndDate(updateDTO.DoctorId, updateDTO.AppointmentDate,token);
            if (schedules == null || schedules.Count == 0)
            {
                throw new Exception("No schedules found for the doctor on the specified date");
            }
            var isSlotAvailable = schedules.Any(s => s.IsAvailable && updateDTO.StartTime >= s.StartTime && updateDTO.EndTime <= s.EndTime);
            if (!isSlotAvailable)
            {
                throw new Exception("No available slot for the specified time");
            }
           
            _mapper.Map(updateDTO, appointment);
            await _repository.Update(id, appointment);
            return updateDTO;
        }

    }
}
