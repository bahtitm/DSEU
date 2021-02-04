using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    internal class DatabookHistoryConfiguration : IEntityTypeConfiguration<DatabookHistory>
    {
        public void Configure(EntityTypeBuilder<DatabookHistory> builder)
        {

        }
    }
}
