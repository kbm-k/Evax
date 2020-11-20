using Inventory.Core.Entities;
using Inventory.Core.Interfaces.Repositories;
using Inventory.Infrastructure.Data;

namespace Inventory.Infrastructure.Repositories
{
    /// <summary>
    /// History repository for the methods related
    /// only to History entity
    /// </summary>
    internal class HistoryRepository : BaseAsyncRepository<History>, IHistoryRepository
    {
        public HistoryRepository(InventoryContext dbContext) : base(dbContext) { }
    }
}
