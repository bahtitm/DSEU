using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class FolderConfiguration : IEntityTypeConfiguration<Folder>
    {
        public void Configure(EntityTypeBuilder<Folder> builder)
        {

        }
    }
}
