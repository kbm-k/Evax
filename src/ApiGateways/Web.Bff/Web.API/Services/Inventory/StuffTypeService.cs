using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcInventory;
using Web.API.Models.Inventory;
using Web.API.Services.Inventory.Interfaces;
using InventoryClient = GrpcInventory.Inventory.InventoryClient;

namespace Web.API.Services.Inventory
{
    public class StuffTypeService : IStuffTypeService
    {
        private readonly InventoryClient _inventoryClient;
        private readonly IMapper _mapper;

        public StuffTypeService(InventoryClient inventoryClient, IMapper mapper)
        {
            _inventoryClient = inventoryClient;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StuffTypeModel>> GetStuffTypesAsync()
        {
            var stuffTypes = await _inventoryClient.GetStuffTypesAsync(new EmptyRequest());

            return _mapper.Map<IEnumerable<StuffTypeModel>>(stuffTypes.Items);
        }

        public async Task<StuffTypeModel> AddStuffTypeAsync(StuffTypeModel stuffType)
        {
            var stuffTypeResponse = await _inventoryClient.AddStuffTypeAsync(_mapper.Map<AddStuffTypeRequest>(stuffType));

            return _mapper.Map<StuffTypeModel>(stuffTypeResponse);
        }

        public async Task UpdateStuffTypeAsync(StuffTypeModel stuffType) => await _inventoryClient.UpdateStuffTypeAsync(_mapper.Map<UpdateStuffTypeRequest>(stuffType));

        public async Task DeleteStuffTypeAsync(int id) =>
            await _inventoryClient.DeleteStuffTypeAsync(new DeleteStuffTypeRequest
            {
                Id = id
            });
    }
}
