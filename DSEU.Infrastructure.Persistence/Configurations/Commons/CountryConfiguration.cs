using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Infrastructure.Persistence.Configurations.Commons
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(e => e.Name)
                .IsRequired().HasMaxLength(60);

            builder.HasMany(p => p.Regions).WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryId).OnDelete(DeleteBehavior.Restrict);

        }
    }

    
}
