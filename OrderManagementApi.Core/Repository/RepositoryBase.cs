using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace OrderManagementApi.Core.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        public DbContext Context;

        public RepositoryBase(DbContext context)
        {
            Context = context;
        }

        public async Task<IList<T>> GetAllAsync(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            if (predicates != null && predicates.Any())
            {
                query = predicates.Aggregate(query, (current, predicate) => current.Where(predicate));
            }

            if (includeProperties != null && includeProperties.Any())
            {
                query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await (predicate == null ? Context.Set<T>().CountAsync() : Context.Set<T>().CountAsync(predicate));
        }

        public async Task DeleteAsyncRange(IEnumerable<T> entities)
        {
            await Task.Run(() => { Context.Set<T>().RemoveRange(entities); });
            await Context.SaveChangesAsync();
        }

        public IQueryable<T> GetAsQueryable()
        {
            return Context.Set<T>().AsQueryable();
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => { Context.Set<T>().Remove(entity); });
            await Context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(IList<Expression<Func<T, bool>>> predicates, IList<Expression<Func<T, object>>> includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            if (predicates != null && predicates.Any())
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate); // isActive==false && isDeleted==true
                }
            }

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {

                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            query = query.Where(predicate);

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking()?.SingleOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Context.Set<T>().Update(entity).Entity);
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
