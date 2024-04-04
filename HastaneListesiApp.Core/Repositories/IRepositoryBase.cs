using HastaneListesiApp.Core.Entities;
using System.Linq.Expressions;

namespace HastaneListesiApp.Core.Repositories
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<T?> GetById(int id, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, string include = null, CancellationToken cancellationToken = default);
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task<T?> UpdateAsync(int id, T entity, CancellationToken cancellationToken = default);
        Task<T?> DeleteAsync(int id, CancellationToken cancellationToken = default);

    }
}
