namespace BillingService.Models.DTO
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public int AppointmentId { get; set; }
        public int InvoiceId { get; set; }
        public float Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
    }

}
