using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Infrastructure.Persistence.Configurations.Parties
{
    internal class CounterpartyConfiguration : IEntityTypeConfiguration<Counterparty>
    {
        public virtual void Configure(EntityTypeBuilder<Counterparty> builder)
        {
            builder.HasIndex(e => e.Name);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.HasOne(p => p.Region).WithMany()
                .HasForeignKey(p => p.RegionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Locality)
                .WithMany()
                .HasForeignKey(p => p.LocalityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Bank)
                .WithMany()
                .HasForeignKey(p => p.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasDiscriminator(p => p.Type)
                .HasValue<Bank>("Bank")
                .HasValue<Person>("Person")
                .HasValue<Domain.Entities.Parties.Company>("Company");
        }
    }
}
