using DSEU.Domain.Entities.RealEstates;
using Microsoft.EntityFrameworkCore;

namespace DSEU.Infrastructure.Persistence.Configurations.RealEstates
{
    public class RealEstateConfiguration : IEntityTypeConfiguration<RealEstate>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RealEstate> builder)
        {
            //throw new System.NotImplementedException();
        }
    }
}
