using System.Linq.Expressions;
using BillingService.Contexts;
using BillingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingService.Repositories
{
    public class InvoiceRepository : Repository<int, Invoice>
    {
        public InvoiceRepository(BillingContext billingContext)
        {
            _context = billingContext;  
        }
        public async override Task<Invoice> Get(int key)
        {
            var invoice = _context.Invoices.Find(key);
            if (invoice == null)
            {
                throw new Exception("Entity not found");
            }
            return invoice;
        }
        public async override Task<Invoice> Find(Expression<Func<Invoice, bool>> predicate)
        {
            return await _context.Invoices.Where(predicate).FirstOrDefaultAsync();
        }

        public async override Task<ICollection<Invoice>> GetAll()
        {
            if (_context.Invoices.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _context.Invoices.ToListAsync();
        }
    }
}
