using Inventory.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Core.Interfaces.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<History>> GetHistoryAsync();

        Task AddHistoryAsync(History history);
        Task UpdateHistoryAsync(History history);
        Task DeleteHistoryAsync(int id);
    }
}