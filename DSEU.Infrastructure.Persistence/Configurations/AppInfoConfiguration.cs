using DSEU.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations
{
    internal class AppInfoConfiguration : IEntityTypeConfiguration<AppMigrationHistory>
    {
        public void Configure(EntityTypeBuilder<AppMigrationHistory> builder)
        {

        }
    }
}
