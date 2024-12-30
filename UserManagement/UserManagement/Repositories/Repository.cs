using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using UserManagement.Contexts;
using UserManagement.Interfaces;

namespace UserManagement.Repositories
{
    public abstract class Repository<K, T> : IRepository<K, T> where T : class
    {
        protected  UserAuthContext _context;
        public abstract Task<ICollection<T>> GetAll();

        public abstract Task<T> Get(K key);

        public async Task<T> GetByString(string  key)
        { 
            var entity = await _context.Set<T>().FirstOrDefaultAsync(e => EF.Property<string>(e, "Email") == key); 
            if (entity == null) 
            { 
                throw new Exception("Entity not found"); 
            } 
            return entity; 
        }

        public async Task<T> Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

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
