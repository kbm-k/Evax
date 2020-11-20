using Inventory.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Data.Configurations
{
    public class HistoryEntityTypeConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.ToTable("History");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Action).HasColumnType("tinyint");

            builder.Property(x => x.Reason).HasMaxLength(1000);
        }
    }
}
