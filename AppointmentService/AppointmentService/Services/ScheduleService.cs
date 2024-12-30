using System.Net.Http;
using System.Net.Http.Headers;
using AppointmentService.Interfaces;
using AppointmentService.Models.DTO;
using Newtonsoft.Json;

namespace AppointmentService.Services
{
    public class ScheduleService : IScheduleService
    {
        HttpClient _httpClient;
        public ScheduleService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<ICollection<ScheduleDTO>> GetSchedulesByDoctorId(int doctorId,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"http://localhost:5071/api/doctors/{doctorId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var scheduledto = JsonConvert.DeserializeObject<ICollection<ScheduleDTO>>(content);
                return scheduledto;
            }
            throw new Exception("cannot get the schedule  data");
        }
        public async Task<ICollection<ScheduleDTO>> GetSchedulesByDoctorIdAndDate(int doctorId, DateTime date,string token)
        {
            var allSchedules = await GetSchedulesByDoctorId(doctorId,token);
           
            var filteredSchedules = allSchedules.Where(s => s.StartTime.Date <= date.Date && s.EndTime.Date >= date.Date).ToList();
            return filteredSchedules;
        }
    }
}
