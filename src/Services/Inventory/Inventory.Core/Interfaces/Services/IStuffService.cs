using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory.Core.Entities;

namespace Inventory.Core.Interfaces.Services
{
    public interface IStuffService
    {
        Task<IEnumerable<Stuff>> GetStuffAsync();

        Task AddStuffAsync(Stuff stuffType);
        Task UpdateStuffAsync(Stuff stuffType);
        Task DeleteStuffAsync(int id);
    }
}