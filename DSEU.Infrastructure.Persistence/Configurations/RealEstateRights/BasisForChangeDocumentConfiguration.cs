using DSEU.Domain.Entities.RealEstateRights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.RealEstateRights
{
    public class BasisForChangeDocumentConfiguration : IEntityTypeConfiguration<BasisForChangeDocument>
    {
        public void Configure(EntityTypeBuilder<BasisForChangeDocument> builder)
        {
            
        }
    }
}
