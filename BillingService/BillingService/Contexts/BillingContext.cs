using BillingService.Models;
using Microsoft.EntityFrameworkCore;


namespace BillingService.Contexts
{
    public class BillingContext : DbContext
    {

        public BillingContext(DbContextOptions<BillingContext> options) : base(options)
        {

        }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

    }
}
