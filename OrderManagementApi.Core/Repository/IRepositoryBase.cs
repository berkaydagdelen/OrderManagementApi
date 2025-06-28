using System.Linq.Expressions;

namespace OrderManagementApi.Core.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includeProperties);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<IList<T>> GetAllAsync(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includeProperties);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        Task DeleteAsyncRange(IEnumerable<T> entities);
        IQueryable<T> GetAsQueryable();
    }
}
