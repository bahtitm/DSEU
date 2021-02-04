using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class RoleRecipientLinksConfiguration : IEntityTypeConfiguration<RoleRecipientLinks>
    {
        public void Configure(EntityTypeBuilder<RoleRecipientLinks> builder)
        {
        }
    }
}
