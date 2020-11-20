using Inventory.Core.Entities;
using Inventory.Core.Interfaces.Repositories;
using Inventory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Repositories
{
    internal abstract class BaseAsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly InventoryContext DbContext;
        protected DbSet<T> DbSet => DbContext.Set<T>();

        protected BaseAsyncRepository(InventoryContext dbContext) => DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate) => await DbSet.Where(predicate).ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync() => await DbSet.ToListAsync();

        public async ValueTask<T> GetByIdAsync(int id) => await DbSet.FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            var entityEntry = DbContext.Entry(entity);
            if (entityEntry.State != EntityState.Detached)
                entityEntry.State = EntityState.Added;
            else
                await DbSet.AddAsync(entity);

            return entity;
        }

        public void Update(T entity)
        {
            var entityEntry = DbContext.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
                DbSet.Attach(entity);
            entityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entityEntry = DbContext.Entry(entity);
            if (entityEntry.State != EntityState.Deleted)
                entityEntry.State = EntityState.Deleted;
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return;
            Delete(entity);
        }
    }
}
