using Inventory.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Data.Configurations
{
    public class StuffEntityTypeConfiguration : IEntityTypeConfiguration<Stuff>
    {
        public void Configure(EntityTypeBuilder<Stuff> builder)
        {
            builder.ToTable("Stuff");

            builder.HasKey(x => new
            {
                x.StuffTypeId,
                x.Brand,
                x.PurchaseDate
            });


            // There is no navigation property in the History entity (Stuff),
            // there is conceptually a reference or collection on the other end of the relationship
            builder.HasMany(x => x.Histories).WithOne()
                .HasForeignKey(x => x.StuffId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Access History collection property through the field
            builder.Navigation(x => x.Histories).UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");

            builder.Property(x => x.Brand).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Description).HasMaxLength(500);
        }
    }
}
