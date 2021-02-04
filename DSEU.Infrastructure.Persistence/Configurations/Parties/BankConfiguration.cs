using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Infrastructure.Persistence.Configurations.Parties
{
    internal class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasIndex(p => p.BIC).IsUnique();

            builder.Property(p => p.BIC)
                .IsRequired(false);
        }
    }
}
