using System.ComponentModel.DataAnnotations;

namespace BillingService.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public float Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public bool IsPaid { get; set; }
        public string PaymentMethod { get; set; }=string.Empty;
    }

}
