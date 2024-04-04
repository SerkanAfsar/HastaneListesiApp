using HastaneListesiApp.Core.Entities;
using HastaneListesiApp.Core.Exceptions;
using HastaneListesiApp.Core.Repositories;
using HastaneListesiApp.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HastaneListesiApp.Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly AppDbContext appDbContext;
        private readonly DbSet<T> dbSet;

        public RepositoryBase(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            this.dbSet = this.appDbContext.Set<T>();

        }

        public virtual async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await this.dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        public virtual async Task<T?> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await this.GetById(id, cancellationToken);
            if (entity != null)
            {
                await Task.Run(() => this.dbSet.Remove(entity), cancellationToken);
                return entity;
            }
            return null;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, string include = null, CancellationToken cancellationToken = default)
        {
            var query = this.dbSet.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (include != null)
            {
                query = query.Include(include);
            }
            return await query.AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<T?> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await this.dbSet.FindAsync(id, cancellationToken) ?? throw new CustomNotFoundException($"{typeof(T).Name} With Id {id} Not Found");
        }

        public virtual async Task<T?> UpdateAsync(int id, T entity, CancellationToken cancellationToken = default)
        {
            var result = await GetById(id);
            if (result != null)
            {
                await Task.Run(() => this.appDbContext.Entry(result).CurrentValues.SetValues(entity), cancellationToken);
                return entity;
            }
            return null;
        }
    }
}
