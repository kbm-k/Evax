using Inventory.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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

    public class InventoryDbContextFactory : IDesignTimeDbContextFactory<InventoryContext>
    {
        public InventoryContext CreateDbContext(string[] args)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<InventoryContext>().UseSqlServer(
                    "Server=PC;Initial Catalog=Inventory;Integrated Security=true;user id=sa;password=1");

            return new InventoryContext(optionsBuilder.Options);
        }
    }
}
