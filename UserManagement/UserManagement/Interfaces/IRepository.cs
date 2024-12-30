namespace UserManagement.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        Task<T> Get(K key);
        Task<T> GetByString(string key);
        Task<ICollection<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(K key,T entity);
        Task<T> Delete(K key);
    }
}
