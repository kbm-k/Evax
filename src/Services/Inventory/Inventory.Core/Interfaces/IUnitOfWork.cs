using Inventory.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Inventory.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IStuffTypeRepository StuffTypeRepository { get; }
        IStuffRepository StuffRepository { get; }
        IHistoryRepository HistoryRepository { get; }

        Task CommitAsync();
    }
}
