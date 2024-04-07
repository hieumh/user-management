using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domains.Interfaces;

namespace UserManagement.Infrastructures.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private RepositoryContext _repositoryContext { get; set; }
        public BaseRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Task<IQueryable<T>> FindAllAsync()
        {
            return (Task<IQueryable<T>>)_repositoryContext.Set<T>().AsNoTracking<T>();
        }

        public Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return (Task<IQueryable<T>>)_repositoryContext.Set<T>().Where<T>(expression).AsNoTracking();
        }

        public async Task<IQueryable<T>> CreateAsync(T entity)
        {
            var result = await _repositoryContext.Set<T>().AddAsync(entity);
            return (IQueryable<T>)result.Entity;
        }

        public async Task UpdateAsync(T entity, string keyField)
        {
            var entityType = typeof(T);
            var keyFieldName = entityType.GetProperty(keyField);

            if (keyFieldName is null)
            {
                throw new ArgumentException($"Key field '{keyField}' not found in entity type '{entityType.Name}'");
            }

            var keyValue = keyFieldName.GetValue(entity);
            if (keyValue is null)
            {
                throw new ArgumentException($"Value for new field '{keyValue}' is null");
            }

            var existingEntity = await _repositoryContext.Set<T>().FindAsync(keyValue);

            if (existingEntity is null)
            {
                throw new ArgumentException($"Entity with key value '{keyValue}' not found.");
            }

            _repositoryContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
        }
    };
}