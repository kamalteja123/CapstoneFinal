using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillingService.Filters;
using BillingService.Interfaces;
using BillingService.Models.DTO;
using Microsoft.AspNetCore.Authorization;
namespace BillingService.Controllers
{
    [Route("api/billing")]
    [ApiController]
    [CustomExceptionFilter]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpGet("invoice/{id:int}")]
        [Authorize]
        public async Task<ActionResult<InvoiceDTO>> GenerateInvoice(int id)
        {
            var invoice= await _invoiceService.GetInvoice(id);
            return Ok(invoice);
        }
        [HttpPost("invoice")]
        [Authorize(Roles = "Patient")]
        public async Task<ActionResult<InvoiceDTO>> ProcessInvoice(InvoiceDTO invoiceDTO)
        {
            var addInvoice=await _invoiceService.CreateInvoice(invoiceDTO); 
            return Ok(addInvoice);
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles ="Patient")]
        public async Task<ActionResult<InvoiceDTO>> DeleteInvoice(int id)
        {
            var invoiceDelete = await _invoiceService.DeleteInvoice(id);    
            return Ok(invoiceDelete);
        }
    }
}
