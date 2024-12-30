using System.Linq.Expressions;
using BillingService.Contexts;
using BillingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingService.Repositories
{
    public class PaymentRepository : Repository<int, Payment>
    {
        public PaymentRepository(BillingContext billingContext)
        {
            _context = billingContext;
        }

        public async override Task<Payment> Find(Expression<Func<Payment, bool>> predicate)
        {
            return await _context.Payments.Where(predicate).FirstOrDefaultAsync();
        }

       
        public async override Task<Payment> Get(int key)
        {
            var payment = _context.Payments.Find(key);
            if (payment == null)
            {
                throw new Exception("Entity not found");
            }
            return payment;
        }

        public async override Task<ICollection<Payment>> GetAll()
        {
            if (_context.Payments.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _context.Payments.ToListAsync();

        }
       

    }
}
