using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Content;

namespace DSEU.Infrastructure.Persistence.Configurations.Content
{
    internal class AssociatedApplicationConfiguration : IEntityTypeConfiguration<AssociatedApplication>
    {
        public void Configure(EntityTypeBuilder<AssociatedApplication> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Extension).IsRequired();
            builder.HasIndex(p => p.Extension).IsUnique(true);
           
        }
    }

}
