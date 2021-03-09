using DSEU.Domain.Entities.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            //builder.Property(p => p.LoginName).IsRequired(true);
            //builder.HasIndex(p => p.LoginName).IsUnique(true);
        }
    }
}
