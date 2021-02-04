using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasOne(p => p.Parent)
                   .WithMany()
                   .HasForeignKey(p => p.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.RecipientLinks)
                 .WithOne(p => p.Group)
                 .HasForeignKey(p => p.GroupId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
