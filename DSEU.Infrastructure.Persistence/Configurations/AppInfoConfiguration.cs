using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities;

namespace DSEU.Infrastructure.Persistence.Configurations
{
    internal class AppInfoConfiguration : IEntityTypeConfiguration<AppInfo>
    {
        public void Configure(EntityTypeBuilder<AppInfo> builder)
        {

        }
    }
}
