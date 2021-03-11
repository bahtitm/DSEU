using DSEU.Domain.Entities.OurOrganization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    public class SystemUserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
        }
    }
}
