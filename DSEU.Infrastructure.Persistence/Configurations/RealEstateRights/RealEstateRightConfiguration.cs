using DSEU.Domain.Entities.RealEstateRights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.RealEstateRights
{
    internal class RealEstateRightConfiguration : IEntityTypeConfiguration<RealEstateRight>
    {
        public void Configure(EntityTypeBuilder<RealEstateRight> builder)
        {
           // builder.Property(p => p.Name).IsRequired();

            //builder.OwnsOne(p => p.Applicant);
        }
    }
}
