using DSEU.Domain.Entities.RealEstateRights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.RealEstateRights
{
    public class RealEstateOwnRightConfiguration : IEntityTypeConfiguration<RealEstateOwnRight>
    {
        public void Configure(EntityTypeBuilder<RealEstateOwnRight> builder)
        {
            //throw new System.NotImplementedException();
        }
    }
}
