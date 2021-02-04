using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Company;

namespace DSEU.Infrastructure.Persistence.Configurations.Company
{
    internal class DepartmentRecipientLinksConfiguration : IEntityTypeConfiguration<DepartmentRecipientLinks>
    {
        public void Configure(EntityTypeBuilder<DepartmentRecipientLinks> builder)
        {
            
        }
    }
}
