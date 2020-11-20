using Inventory.Core.Entities;
using Inventory.Core.Interfaces;
using Inventory.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Core.Services
{
    public class StuffTypeService : IStuffTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StuffTypeService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<StuffType>> GetStuffTypesAsync() => await _unitOfWork.StuffTypeRepository.GetAllAsync();

        public async Task<StuffType> AddStuffTypeAsync(StuffType stuffType)
        {
            var addedEntity = await _unitOfWork.StuffTypeRepository.AddAsync(stuffType);
            await _unitOfWork.CommitAsync();

            return addedEntity;
        }

        public async Task UpdateStuffTypeAsync(StuffType stuffType)
        {
            _unitOfWork.StuffTypeRepository.Update(stuffType);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteStuffTypeAsync(int id)
        {
            await _unitOfWork.StuffTypeRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }
    }
}