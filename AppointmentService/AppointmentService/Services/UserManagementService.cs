using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using AppointmentService.Interfaces;
using AppointmentService.Models.DTO;
using Newtonsoft.Json;

namespace AppointmentService.Services
{
    public class UserManagementService : IUserManagementService
    {
        HttpClient _httpClient;
        public UserManagementService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<PatientDTO> GetPatient(int patientId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"http://localhost:5193/api/Patient/ById?id={patientId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var patientdto = JsonConvert.DeserializeObject<PatientDTO>(content);
                return patientdto;
            }
            throw new Exception("can not find the patient details");
        }
    }
}
