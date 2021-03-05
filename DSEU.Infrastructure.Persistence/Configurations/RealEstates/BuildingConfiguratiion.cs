using DSEU.Domain.Entities.RealEstates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.RealEstates
{
    public class BuildingConfiguratiion : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            //throw new System.NotImplementedException();
        }
    }
}
