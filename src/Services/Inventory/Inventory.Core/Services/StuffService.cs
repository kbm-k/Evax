using Inventory.Core.Entities;
using Inventory.Core.Interfaces;
using Inventory.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Core.Services
{
    public class StuffService : IStuffService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StuffService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Stuff>> GetStuffAsync() => await _unitOfWork.StuffRepository.GetAllAsync();

        public async Task AddStuffAsync(Stuff stuff)
        {
            await _unitOfWork.StuffRepository.AddAsync(stuff);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateStuffAsync(Stuff stuff)
        {
            _unitOfWork.StuffRepository.Update(stuff);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteStuffAsync(int id)
        {
            await _unitOfWork.StuffRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }
    }
}