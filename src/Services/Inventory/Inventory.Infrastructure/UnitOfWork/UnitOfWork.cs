using Inventory.Core.Interfaces;
using Inventory.Core.Interfaces.Repositories;
using Inventory.Infrastructure.Data;
using Inventory.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable, IAsyncDisposable
    {
        private InventoryContext DbContext { get; }

        private IStuffTypeRepository? _stuffTypeRepository;
        private IStuffRepository? _stuffRepository;
        private IHistoryRepository? _historyRepository;

        public IStuffTypeRepository StuffTypeRepository => _stuffTypeRepository ??= new StuffTypeRepository(DbContext);
        public IStuffRepository StuffRepository => _stuffRepository ??= new StuffRepository(DbContext);
        public IHistoryRepository HistoryRepository => _historyRepository ??= new HistoryRepository(DbContext);

        public UnitOfWork(InventoryContext dbContext) => DbContext = dbContext;

        public async Task CommitAsync() => await DbContext.SaveChangesAsync();

        #region IDisposable

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        protected virtual async Task DisposeAsync(bool disposing)
        {
            if (disposing && DbContext != null) await DbContext.DisposeAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) DbContext?.Dispose();
        }

        ~UnitOfWork() => Dispose(false);

        #endregion
    }
}
