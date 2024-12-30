using System.Net.Http.Headers;
using DoctorService.Interfaces;
using DoctorService.Models.DTO;
using Newtonsoft.Json;

namespace DoctorService.Services
{
    public class UserManagementService : IUserManagementService
    {
        HttpClient _httpClient; 
        public UserManagementService() 
        { 
            _httpClient = new HttpClient();
        }
        public async Task<DoctorDTO> GetDoctorById(int doctorId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"http://localhost:5193/api/doctors/ById?id={doctorId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var doctordto = JsonConvert.DeserializeObject<DoctorDTO>(content);
                return doctordto;
            }
            throw new Exception("can get the doctor data");
        }
    }
}
