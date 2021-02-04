using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class RelationTypeMappingConfiguration : IEntityTypeConfiguration<RelationTypeMapping>
    {
        public void Configure(EntityTypeBuilder<RelationTypeMapping> builder)
        {
        }
    }
}
