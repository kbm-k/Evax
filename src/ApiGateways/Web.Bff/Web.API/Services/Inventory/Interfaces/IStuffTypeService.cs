using System.Collections.Generic;
using System.Threading.Tasks;
using Web.API.Models.Inventory;

namespace Web.API.Services.Inventory.Interfaces
{
    public interface IStuffTypeService
    {
        Task<IEnumerable<StuffTypeModel>> GetStuffTypesAsync();

        Task<StuffTypeModel> AddStuffTypeAsync(StuffTypeModel stuffType);

        Task UpdateStuffTypeAsync(StuffTypeModel stuffType);

        Task DeleteStuffTypeAsync(int id);
    }
}