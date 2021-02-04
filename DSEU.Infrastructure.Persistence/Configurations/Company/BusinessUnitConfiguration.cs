using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Company;

namespace DSEU.Infrastructure.Persistence.Configurations.Company
{
    internal class BusinessUnitConfiguration : IEntityTypeConfiguration<BusinessUnit>
    {
        public void Configure(EntityTypeBuilder<BusinessUnit> builder)
        {
            builder.Property(e => e.Name)
                   .IsRequired();

            builder.HasIndex(p => p.Name);

            builder.Property(e => e.CEO).IsRequired(false);
            builder.HasIndex(e => e.CEO).IsUnique();

            builder.Property(e => e.Account);

            builder.HasIndex(e => e.Code).IsUnique();

            builder.HasOne(p => p.HeadCompany)
                .WithMany()
                .HasForeignKey(p => p.HeadCompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Company)
              .WithOne()
              .HasForeignKey<BusinessUnit>(p => p.CompanyId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Region)
                .WithMany()
                .HasForeignKey(p => p.RegionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Locality)
                .WithMany()
                .HasForeignKey(p => p.LocalityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.BusinessUnitHead)
                .WithMany()
                .HasForeignKey(p => p.CEO)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Bank)
                .WithMany()
                .HasForeignKey(p => p.BankId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
