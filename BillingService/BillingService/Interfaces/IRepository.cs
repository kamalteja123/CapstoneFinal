using System.Linq.Expressions;

namespace BillingService.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        Task<T> Get(K key);
        Task<ICollection<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Find(Expression<Func<T, bool>> predicate);
        Task<T> Update(K key,T entity);
        Task<T> Delete(K key);
      
    }
}
