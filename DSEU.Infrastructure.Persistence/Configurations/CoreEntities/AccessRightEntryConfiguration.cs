using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class AccessRightEntryConfiguration : IEntityTypeConfiguration<AccessRightEntry>
    {
        public void Configure(EntityTypeBuilder<AccessRightEntry> builder)
        {
            builder.HasIndex(p => new { p.RecipientId, p.RootId }).IsUnique();

            builder.HasOne(p => p.Recipient)
                   .WithMany()
                   .HasForeignKey(p => p.RecipientId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
