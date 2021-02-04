using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class GroupRecipientLinksConfiguration : IEntityTypeConfiguration<GroupRecipientLinks>
    {
        public void Configure(EntityTypeBuilder<GroupRecipientLinks> builder)
        {
            builder.HasKey(p => new { p.GroupId, p.MemberId });

            builder.HasOne(p => p.Member)
                   .WithMany()
                   .HasForeignKey(p => p.MemberId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Group)
                   .WithMany(p => p.RecipientLinks)
                   .HasForeignKey(p => p.GroupId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
