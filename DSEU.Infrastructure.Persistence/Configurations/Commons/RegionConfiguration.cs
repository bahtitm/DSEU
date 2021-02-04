using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Infrastructure.Persistence.Configurations.Commons
{
    internal class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasIndex(p => new { p.CountryId, p.Name }).IsUnique();

            builder.HasIndex(p => p.Name);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder.HasMany(p => p.Localities)
                .WithOne(p => p.Region)
                .HasForeignKey(p => p.RegionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
