using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Content;

namespace DSEU.Infrastructure.Persistence.Configurations.Content
{
    internal class FilesTypeConfiguration : IEntityTypeConfiguration<FilesType>
    {
        public void Configure(EntityTypeBuilder<FilesType> builder)
        {
            builder.Property(p => p.Name)
                   .HasMaxLength(60)
                   .IsRequired();

            builder.HasMany(p => p.AssociatedApplications)
                    .WithOne(p => p.FilesType)
                    .HasForeignKey(p => p.FilesTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
