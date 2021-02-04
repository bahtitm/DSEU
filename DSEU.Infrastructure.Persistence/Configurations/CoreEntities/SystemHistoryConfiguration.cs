using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class SystemHistoryConfiguration : IEntityTypeConfiguration<SystemHistory>
    {
        public void Configure(EntityTypeBuilder<SystemHistory> builder)
        {
        }
    }
}
