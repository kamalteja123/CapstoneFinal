using BillingService.Models;
using BillingService.Models.DTO;

namespace BillingService.Interfaces
{
    public interface IPaymentService
    {
        public Task<PaymentDTO> PaymentProcess(PaymentDTO paymentdto);
        public Task<PaymentDTO> RefundProcess(int id);
    }
}
