using System.Linq.Expressions;

namespace BarberConnect.Api.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        
        Task<T> CreateAsync(T entity);
        
        Task<T> UpdateAsync(T entity);
        
        Task<T> DeleteAsync(T entity);
    }
}