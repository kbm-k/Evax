using Inventory.Core.Entities;
using Inventory.Core.Interfaces;
using Inventory.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Core.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HistoryService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<History>> GetHistoryAsync() => await _unitOfWork.HistoryRepository.GetAllAsync();

        public async Task AddHistoryAsync(History history)
        {
            await _unitOfWork.HistoryRepository.AddAsync(history);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateHistoryAsync(History history)
        {
            _unitOfWork.HistoryRepository.Update(history);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteHistoryAsync(int id)
        {
            await _unitOfWork.HistoryRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }
    }
}