using Newtonsoft.Json;
using System.Net.Http.Headers;
using PatientRecordService.Interfaces;
using PatientRecordService.Models.DTO;

namespace PatientRecordService.Services
{
    public class UserManagementService : IUserManagementService
    {
        HttpClient _httpClient;
        public UserManagementService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<PatientProfileDTO> GetPatientById(int patientId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"http://localhost:5193/api/Patient/ById?id={patientId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var patientdto = JsonConvert.DeserializeObject<PatientProfileDTO>(content);
                return patientdto;
            }
            throw new Exception("can get the patient data");
        }
    }
}

