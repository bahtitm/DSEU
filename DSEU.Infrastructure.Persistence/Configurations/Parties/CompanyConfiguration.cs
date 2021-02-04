using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.Parties
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Domain.Entities.Parties.Company>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Parties.Company> builder)
        {
            
        }
    }
}
