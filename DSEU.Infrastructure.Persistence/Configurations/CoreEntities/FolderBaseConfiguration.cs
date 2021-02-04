using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class FolderBaseConfiguration : IEntityTypeConfiguration<FolderBase>
    {
        public void Configure(EntityTypeBuilder<FolderBase> builder)
        {
            builder.ToTable("Folder");
        }
    }
}
