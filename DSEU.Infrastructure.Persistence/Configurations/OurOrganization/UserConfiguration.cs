using DSEU.Domain.Entities.OurOrganization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.OurOrganization
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            
            builder.Property(p => p.LoginName).IsRequired(true);
            builder.Property(p => p.UserId).IsRequired(false);
            builder.HasIndex(p => p.UserId).IsUnique(true);
            builder.HasIndex(p => p.Name);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Phone).IsRequired(false);
            builder.Property(e => e.Email).IsRequired(false).HasMaxLength(150);

            builder.HasOne(p => p.JobTitle)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.JobTitleId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(p => p.OrganizationalUnit)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.OrganizationalUnitId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
