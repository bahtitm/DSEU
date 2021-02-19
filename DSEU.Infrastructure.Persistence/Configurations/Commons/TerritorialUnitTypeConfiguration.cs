using DSEU.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.Commons
{
    internal class TerritorialUnitTypeConfiguration : IEntityTypeConfiguration<TerritorialUnitType>
    {
        public void Configure(EntityTypeBuilder<TerritorialUnitType> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}
