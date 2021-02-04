using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class AccessRightTypeConfiguration : IEntityTypeConfiguration<AccessRightsType>
    {
        public void Configure(EntityTypeBuilder<AccessRightsType> builder)
        {
            builder.HasIndex(p => new { p.EntityTypeGuid, p.AccessRightsTypeArea, p.Operation, p.Status }).IsUnique();

            builder.HasIndex(p => p.Operation);
        }
    }
}
