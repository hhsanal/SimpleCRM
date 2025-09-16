using System.Linq.Expressions;

namespace Domain.Abstractions
{
    public interface IRepository<T>
    {
        Task AddAsync(T Entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(List<T> EntityList, CancellationToken cancellationToken = default);
        Task DeleteByExpressionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        void Update(T Entity);
        void Delete(T Entity);
        void UpdateRange(ICollection<T> entities);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetWhere(Expression<Func<T, bool>> expression);
        IQueryable<T> GetQueryable();
        Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<T> GetOnlyRecordAsync(CancellationToken cancellationToken = default);
    }
}
