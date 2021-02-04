using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Company;

namespace DSEU.Infrastructure.Persistence.Configurations.Company
{
    internal class JobTitleConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            

            builder.Property(e => e.Name)
                .IsRequired();

            builder.HasIndex(p => p.Name).IsUnique();
        }
    } 
}
