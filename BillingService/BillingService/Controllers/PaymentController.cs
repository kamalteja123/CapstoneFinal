using BillingService.Filters;
using BillingService.Interfaces;
using BillingService.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BillingService.Controllers
{
    [Route("api/billing")]
    [ApiController]
    [CustomExceptionFilter]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<PaymentDTO>> MakePayment(PaymentDTO paymentDTO)
        {
            var payment = await _paymentService.PaymentProcess(paymentDTO);
            return Ok(payment);
        }
        [HttpDelete]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<PaymentDTO>> RefundPayment(int appointmentId)
        {
            var refund=await _paymentService.RefundProcess(appointmentId);
            return Ok(refund);
        }
    }
}
