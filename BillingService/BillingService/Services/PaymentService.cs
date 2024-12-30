using AutoMapper;
using BillingService.Interfaces;
using BillingService.Models;
using BillingService.Models.DTO;
using BillingService.Repositories;

namespace BillingService.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<int,Payment> _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IInvoiceService _invoiceService;
        public PaymentService(IInvoiceService invoiceService,IRepository<int,Payment> paymentRepository,IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }
        public async  Task<PaymentDTO> PaymentProcess(PaymentDTO paymentdto)
        {
            
            var invoice = await _invoiceService.GetInvoice(paymentdto.InvoiceId);
            var payment = _mapper.Map<Payment>(paymentdto);
            var addPayment = await _paymentRepository.Add(payment);
            if (invoice != null)
            {
              
                invoice.IsPaid = true;
                await _invoiceService.UpdateInvoice(invoice);
            }
            return _mapper.Map<PaymentDTO>(addPayment) ;
        }

        public async Task<PaymentDTO> RefundProcess(int appointmentId)
        {

            var refund = await _paymentRepository.Find(p => p.AppointmentId == appointmentId);
            var invoiceslip = await _invoiceService.GetInvoice(refund.InvoiceId);
            await _paymentRepository.Delete(refund.PaymentId);
            if (invoiceslip != null)
            {
                invoiceslip.IsPaid = false;
                await _invoiceService.UpdateInvoice(invoiceslip);
            }
            return _mapper.Map<PaymentDTO>(refund);

        }
       
    }
}
