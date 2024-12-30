using System.Net.Http.Headers;
using System.Text;
using AppointmentService.Interfaces;
using AppointmentService.Models.DTO;
using Newtonsoft.Json;

namespace AppointmentService.Services
{
    public class BillingService : IBillingService
    {
        HttpClient _httpClient;
        public BillingService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<InvoiceDTO> CreateInvoice(InvoiceDTO invoiceDTO, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(JsonConvert.SerializeObject(invoiceDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5095/api/billing/Invoice", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var invoicedto = JsonConvert.DeserializeObject<InvoiceDTO>(responseContent);
                return invoicedto;
            }

            throw new Exception("Failed to create invoice.");
        }

    }
}
