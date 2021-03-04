using DSEU.Domain.Entities.OurOrganization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.OurOrganization
{
    public class OrganizationalUnitConfiguration : IEntityTypeConfiguration<OrganizationalUnit>
    {
        public void Configure(EntityTypeBuilder<OrganizationalUnit> builder)
        {
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
