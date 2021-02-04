using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Content;

namespace DSEU.Infrastructure.Persistence.Configurations.Content
{
    internal class RelationConfiguration : IEntityTypeConfiguration<Relation>
    {
        public void Configure(EntityTypeBuilder<Relation> builder)
        {
            //builder.HasOne(p => p.Source)
            //       .WithMany()
            //       .IsRequired(false)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(p => p.Target)
            //       .WithMany()
            //       .IsRequired(false)
            //       .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.RelationType)
                  .WithMany()
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
