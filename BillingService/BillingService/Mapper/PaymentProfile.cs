using AutoMapper;
using BillingService.Models;
using BillingService.Models.DTO;

namespace BillingService.Mapper
{
    public class PaymentProfile:Profile
    {
        public PaymentProfile()
        {
            
            CreateMap<Invoice, InvoiceDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();  
            
            
          
        }
    }
}
