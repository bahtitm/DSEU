using DSEU.Domain.Entities.RealEstateRights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.RealEstateRights
{
    public class LawEstablishingDocumentConfiguration : IEntityTypeConfiguration<LawEstablishingDocument>
    {
        public void Configure(EntityTypeBuilder<LawEstablishingDocument> builder)
        {

        }        
    }
}
