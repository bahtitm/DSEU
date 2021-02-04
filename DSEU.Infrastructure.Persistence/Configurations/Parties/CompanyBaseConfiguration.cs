using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Infrastructure.Persistence.Configurations.Parties
{
    internal class CompanyBaseConfiguration : IEntityTypeConfiguration<CompanyBase>
    {
        public void Configure(EntityTypeBuilder<CompanyBase> builder)
        {
            builder.HasMany(p => p.Childrens)
                .WithOne(p => p.HeadCompany)
                .HasForeignKey(p => p.HeadCompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
