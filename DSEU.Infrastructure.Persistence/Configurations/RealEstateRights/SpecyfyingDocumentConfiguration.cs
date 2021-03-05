using DSEU.Domain.Entities.RealEstateRights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.RealEstateRights
{
    public class SpecyfyingDocumentConfiguration : IEntityTypeConfiguration<SpecifyingDocument>
    {
        public void Configure(EntityTypeBuilder<SpecifyingDocument> builder)
        {
            
        }
    }
}
