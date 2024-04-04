using HastaneListesiApp.Core.UnitOfWorks;
using HastaneListesiApp.Repository.Contexts;

namespace HastaneListesiApp.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }


        public void CommitChanges()
        {
            this.appDbContext.SaveChanges();
        }

        public async Task<int> CommitChangesAsync(CancellationToken cancellationToken = default)
        {
            return await this.appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
