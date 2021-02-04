using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Identity.EntityConfigurations
{
    internal class UserPasswordHistoryConfiguration : IEntityTypeConfiguration<UserPasswordHistory>
    {
        public void Configure(EntityTypeBuilder<UserPasswordHistory> builder)
        {
            builder.ToTable("AspNetUserPasswordHistory");

            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
