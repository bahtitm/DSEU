using DSEU.Domain.Entities.OurOrganization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.OurOrganization
{
    class UserLocalityConfiguration : IEntityTypeConfiguration<UserLocality>
    {
        public void Configure(EntityTypeBuilder<UserLocality> builder)
        {
            builder.HasKey(prop => new { prop.LocalityId, prop.UserId });

            builder.HasOne(p => p.Locality)
                .WithMany()
                .HasForeignKey(prop => prop.LocalityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.User)
                .WithMany(p => p.Localities)
                .HasForeignKey(prop => prop.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
