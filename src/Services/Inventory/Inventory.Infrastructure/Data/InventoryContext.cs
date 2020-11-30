using Inventory.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Inventory.Infrastructure.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions options) : base(options) { }

        public DbSet<StuffType> StuffTypes { get; set; } = null!;
        public DbSet<Stuff> Stuff { get; set; } = null!;
        public DbSet<History> Histories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
