using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class AccessRightConfiguration : IEntityTypeConfiguration<AccessRight>
    {
        public void Configure(EntityTypeBuilder<AccessRight> builder)
        {
            builder.HasIndex(p => new { p.EntityId, p.EntityTypeGuid }).IsUnique();

            builder.HasMany(p => p.Entries)
                   .WithOne(p => p.Root)
                   .HasForeignKey(p => p.RootId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
