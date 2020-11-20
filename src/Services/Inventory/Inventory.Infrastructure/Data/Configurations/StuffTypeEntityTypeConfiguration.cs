using Inventory.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Data.Configurations
{
    public class StuffTypeEntityTypeConfiguration : IEntityTypeConfiguration<StuffType>
    {
        public void Configure(EntityTypeBuilder<StuffType> builder)
        {
            builder.ToTable("StuffType");
            
            builder.HasKey(x => x.Id);

            // There is no navigation property in the Stuff entity (StuffType),
            // there is conceptually a reference or collection on the other end of the relationship
            builder.HasMany(x => x.Stuff).WithOne().OnDelete(DeleteBehavior.Restrict);

            // Access Stuff collection property through the field
            builder.Navigation(x => x.Stuff).UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Description).HasMaxLength(500);
        }
    }
}
