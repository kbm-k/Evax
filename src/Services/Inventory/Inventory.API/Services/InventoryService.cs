using AutoMapper;
using Grpc.Core;
using Inventory.Core.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using StuffTypeEntity = Inventory.Core.Entities.StuffType;

namespace Inventory.API.Services
{
    public class InventoryService : Inventory.InventoryBase
    {
        private readonly IStuffTypeService _stuffTypeService;
        private readonly IMapper _mapper;
        private readonly ILogger<InventoryService> _logger;
        
        public InventoryService(IStuffTypeService stuffTypeService, IMapper mapper, ILogger<InventoryService> logger)
        {
            _stuffTypeService = stuffTypeService;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task<StuffTypeResponse> AddStuffType(AddStuffTypeRequest request, ServerCallContext context)
        {
            var addedStuffType = await _stuffTypeService.AddStuffTypeAsync(_mapper.Map<StuffTypeEntity>(request));

            return _mapper.Map<StuffTypeResponse>(addedStuffType);
        }

        public override async Task<StuffTypesResponse> GetStuffTypes(EmptyRequest request, ServerCallContext context)
        {
            var stuffTypes = await _stuffTypeService.GetStuffTypesAsync();

            var result = new StuffTypesResponse();
            result.Items.Add(_mapper.Map<List<StuffType>>(stuffTypes));
            
            return result;
        }

        public override async Task<EmptyResponse> UpdateStuffType(UpdateStuffTypeRequest request, ServerCallContext context)
        {
            await _stuffTypeService.UpdateStuffTypeAsync(_mapper.Map<StuffTypeEntity>(request));

            return new EmptyResponse();
        }

        public override async Task<EmptyResponse> DeleteStuffType(DeleteStuffTypeRequest request, ServerCallContext context)
        {
            await _stuffTypeService.DeleteStuffTypeAsync(request.Id);

            return new EmptyResponse();
        }
    }
}
