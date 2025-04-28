using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using POS.Application.Interfaces.Repositories;
using POS.Persistence.Data;

namespace POS.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly POSDbContext _context;
        private IDbContextTransaction? _transaction; 

        public UnitOfWork(POSDbContext context) => _context = context; 

      public async Task BeginTransactionAsync(IsolationLevel isolationLevel )
        {
            _transaction = await _context.Database.BeginTransactionAsync(isolationLevel);
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction is null)
            {
                throw new InvalidOperationException("Transaction has not yet been started");
            }

            await _transaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction is null)
            {
                throw new InvalidOperationException("Transaction has not yet been started");
            }

            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
