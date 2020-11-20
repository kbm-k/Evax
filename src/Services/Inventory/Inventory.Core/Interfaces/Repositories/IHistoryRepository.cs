using Inventory.Core.Entities;

namespace Inventory.Core.Interfaces.Repositories
{
    /// <summary>
    /// History repository interface for the methods
    /// related only to History entity
    /// </summary>
    public interface IHistoryRepository : IAsyncRepository<History>
    {
    }
}