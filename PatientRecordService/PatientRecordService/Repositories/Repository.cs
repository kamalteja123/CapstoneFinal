using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PatientRecordService.Contexts;
using PatientRecordService.Interfaces;

namespace PatientRecordService.Repositories
{
    public abstract class Repository<K, T> : IRepository<K, T> where T : class
    {
        protected  PatientRecordContext _context;
      
        public async Task<T> Add(T entity)
        {
            await  _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<ICollection<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public abstract Task<T> Get(K key);


        public abstract Task<ICollection<T>> GetAll();
        
    }

}
