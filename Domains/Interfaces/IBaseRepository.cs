using System.Linq.Expressions;

namespace UserManagement.Domains.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IQueryable<T>> FindAllAsync();
        Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> CreateAsync(T entity);
        Task UpdateAsync(T entity, string keyField);
        Task DeleteAsync(T entity);
    }
}