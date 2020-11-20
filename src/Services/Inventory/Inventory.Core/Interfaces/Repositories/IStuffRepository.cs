using Inventory.Core.Entities;

namespace Inventory.Core.Interfaces.Repositories
{
    /// <summary>
    /// Stuff repository interface for the methods
    /// related only to Stuff entity
    /// </summary>
    public interface IStuffRepository : IAsyncRepository<Stuff>
    {
    }
}