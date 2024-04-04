namespace HastaneListesiApp.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void CommitChanges();
        Task<int> CommitChangesAsync(CancellationToken cancellationToken = default);
    }
}
