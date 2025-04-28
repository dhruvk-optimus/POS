using System.Data;

namespace POS.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted);
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task<int> SaveChangesAsync();

    }
}
