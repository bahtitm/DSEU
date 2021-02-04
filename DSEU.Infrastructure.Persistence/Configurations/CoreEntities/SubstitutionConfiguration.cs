using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class SubstitutionConfiguration : IEntityTypeConfiguration<Substitution>
    {
        public void Configure(EntityTypeBuilder<Substitution> builder)
        {
            builder.HasIndex(p => new { p.UserId, p.SubstituteId });

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p=>p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Substitute)
                .WithMany()
                .HasForeignKey(p => p.SubstituteId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }


}
