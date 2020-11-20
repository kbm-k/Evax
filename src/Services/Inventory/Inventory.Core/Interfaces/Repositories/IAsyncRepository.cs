using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Inventory.Core.Entities;

namespace Inventory.Core.Interfaces.Repositories
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        ValueTask<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteAsync(int id);
    }
}
