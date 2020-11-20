using Inventory.Core.Entities;
using Inventory.Core.Interfaces.Repositories;
using Inventory.Infrastructure.Data;

namespace Inventory.Infrastructure.Repositories
{
    /// <summary>
    /// Stuff repository for the methods related
    /// only to Stuff entity
    /// </summary>
    internal class StuffRepository : BaseAsyncRepository<Stuff>, IStuffRepository
    {
        public StuffRepository(InventoryContext dbContext) : base(dbContext) { }
    }
}