using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory.Core.Entities;

namespace Inventory.Core.Interfaces.Services
{
    public interface IStuffTypeService
    {
        Task<IEnumerable<StuffType>> GetStuffTypesAsync();

        Task<StuffType> AddStuffTypeAsync(StuffType stuffType);
        Task UpdateStuffTypeAsync(StuffType stuffType);
        Task DeleteStuffTypeAsync(int id);
    }
}