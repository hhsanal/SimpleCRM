using System.Linq.Expressions;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories.EntityFramework
{
    public class Repository<T>(EfContext _context) : IRepository<T> where T : class
    {
        protected readonly EfContext context = _context;
        public async Task AddAsync(T Entity, CancellationToken cancellationToken = default)
        {
            await context.Set<T>().AddAsync(Entity, cancellationToken);
        }

        public async Task AddRangeAsync(List<T> EntityList, CancellationToken cancellationToken = default)
        {
            await context.Set<T>().AddRangeAsync(EntityList, cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().AnyAsync(expression, cancellationToken);
        }

        public async Task DeleteByExpressionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            T entity = await context.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            context.Set<T>().Remove(entity);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetOnlyRecordAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<T>> GetWhere(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }

        public void Update(T Entity)
        {
            context.Entry(Entity).State = EntityState.Modified;
        }
        public void Delete(T Entity)
        {
            context.Entry(Entity).State = EntityState.Deleted;
        }

        public void UpdateRange(ICollection<T> entities)
        {
            context.Set<T>().UpdateRange(entities);
        }

        public IQueryable<T> GetQueryable()
        {
            return context.Set<T>().AsQueryable();
        }
    }
}
