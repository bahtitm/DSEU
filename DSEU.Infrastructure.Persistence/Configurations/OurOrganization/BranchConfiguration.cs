using DSEU.Domain.Entities.OurOrganization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.OurOrganization
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(p => p.Departament)
                .WithMany(p => p.Branches)
                .HasForeignKey(p => p.DepartamentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
