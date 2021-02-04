using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Infrastructure.Persistence.Configurations.Parties
{
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasIndex(e => e.Name);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.HasOne(p => p.Company)
                   .WithMany()
                   .HasForeignKey(p => p.CompanyId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
