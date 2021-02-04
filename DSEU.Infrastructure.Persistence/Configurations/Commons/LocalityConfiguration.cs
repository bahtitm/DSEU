using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Infrastructure.Persistence.Configurations.Commons
{
    internal class LocalityConfiguration : IEntityTypeConfiguration<Locality>
    {
        public void Configure(EntityTypeBuilder<Locality> builder)
        {
            builder.HasIndex(p => new { p.Name, p.RegionId }).IsUnique();

            builder.HasIndex(p => p.Name);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(60);

        }
    }
}
