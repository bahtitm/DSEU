using DSEU.Domain.Entities.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.Property(p => p.UserId).IsRequired(true);
            //builder.HasIndex(p => p.UserId).IsUnique(true);

            //builder.HasOne(p => p.Login)
            //    .WithOne()
            //    .HasForeignKey<User>(p => p.LoginId)
            //    .IsRequired(true)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
