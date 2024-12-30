using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using BillingService.Interfaces;
using BillingService.Contexts;

namespace BillingService.Repositories
{
    public abstract class Repository<K, T> : IRepository<K, T> where T : class
    {
        protected  BillingContext _context;
      
        public async Task<T> Add(T entity)
        {
              _context.Add(entity);
             _context.SaveChanges();
            return entity;
        }



        public abstract Task<T> Find(Expression<Func<T, bool>> predicate);
        

        public abstract Task<T> Get(K key);


        public abstract Task<ICollection<T>> GetAll();

        public async Task<T> Delete(K key)
        {
            var entity = await Get(key);
            if (entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return entity;
            }
            throw new Exception("Entity not found");
        }

        public async Task<T> Update(K key, T entity)
        {
            var myEntity = await Get(key);
            if (myEntity != null)
            {
                _context.Entry(myEntity).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return myEntity;
            }
            throw new Exception("Entity not found");
        }
    }

}
