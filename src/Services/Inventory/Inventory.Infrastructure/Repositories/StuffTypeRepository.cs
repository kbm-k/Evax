using Inventory.Core.Entities;
using Inventory.Core.Interfaces.Repositories;
using Inventory.Infrastructure.Data;

namespace Inventory.Infrastructure.Repositories
{
    /// <summary>
    /// StuffType repository for the methods related
    /// only to StuffType entity
    /// </summary>
    internal class StuffTypeRepository : BaseAsyncRepository<StuffType>, IStuffTypeRepository
    {
        public StuffTypeRepository(InventoryContext dbContext) : base(dbContext) { }
    }
}