using DSEU.Domain.Entities.RealEstateRights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.RealEstateRights
{
    class BasisConfiguration : IEntityTypeConfiguration<Basis>
    {
        public void Configure(EntityTypeBuilder<Basis> builder)
        {

        }
    }
}
