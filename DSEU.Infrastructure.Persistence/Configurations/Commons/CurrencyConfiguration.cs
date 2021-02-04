using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Infrastructure.Persistence.Configurations.Commons
{
    internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
            builder.HasIndex(p => p.AlphaCode).IsUnique();
            builder.HasIndex(p => p.NumericCode).IsUnique();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p => p.ShortName).IsRequired().HasMaxLength(60);
            builder.Property(p => p.AlphaCode).IsRequired().HasMaxLength(3).IsFixedLength();
            builder.Property(p => p.NumericCode).IsRequired().HasMaxLength(3).IsFixedLength();
            builder.Property(p => p.FractionName).IsRequired().HasMaxLength(20);
            builder.Property(p => p.IsDefault).IsRequired();
        }
    }
}
