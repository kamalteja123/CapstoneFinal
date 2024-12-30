using AppointmentService.Models.DTO;

namespace AppointmentService.Interfaces
{
    public interface IBillingService
    {
        public Task<InvoiceDTO> CreateInvoice(InvoiceDTO invoiceDTO,string token);
    }
}
