using AutoMapper;
using BillingService.Interfaces;
using BillingService.Models;
using BillingService.Models.DTO;

namespace BillingService.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepository<int,Invoice> _invoiceRepository;
        private readonly IMapper _mapper;
        public InvoiceService(IRepository<int, Invoice> invoiceRepository,IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task<InvoiceDTO> CreateInvoice(InvoiceDTO dto)
        {
            var invoice = _mapper.Map<Invoice>(dto);
            var addInvoice = await _invoiceRepository.Add(invoice);
            return _mapper.Map<InvoiceDTO>(addInvoice);
        }

        public async Task<InvoiceDTO> DeleteInvoice(int Invoiceid)
        {
            var invoicereceipt= await _invoiceRepository.Get(Invoiceid);
            if (invoicereceipt == null)
            {
                throw new Exception("no invoice found");
            }
            await _invoiceRepository.Delete(Invoiceid);
            return _mapper.Map<InvoiceDTO>(invoicereceipt);
        }

        public async  Task<InvoiceDTO> GetInvoice(int Invoiceid)
        {
           var invoiceSlip= await _invoiceRepository.Get(Invoiceid);
            if (invoiceSlip == null)
            {
                throw new Exception("no invoice found");
            }
            return _mapper.Map<InvoiceDTO>(invoiceSlip);
        }

        public async Task<InvoiceDTO> UpdateInvoice(InvoiceDTO invoicedto)
        {
           var invoice= await _invoiceRepository.Get(invoicedto.InvoiceId);
            if (invoice == null)
            {
                throw new Exception("no invoice to update");
            }
            invoice.IsPaid = invoicedto.IsPaid;
            await _invoiceRepository.Update(invoicedto.InvoiceId, invoice);
            return invoicedto;
        }
    }
}
