using BillingService.Models;
using BillingService.Models.DTO;

namespace BillingService.Interfaces
{
    public interface IInvoiceService
    {
        public Task<InvoiceDTO> CreateInvoice(InvoiceDTO dto);
        public Task<InvoiceDTO> GetInvoice(int Invoiceid);
        public Task<InvoiceDTO> UpdateInvoice(InvoiceDTO invoicedto);
        public Task<InvoiceDTO> DeleteInvoice(int Invoiceid);   
       
    }
}
