using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Infrastructure.Persistence.Configurations.Parties
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.Sex);

            builder.Property(e => e.FirstName)
                .IsRequired();

            builder.Property(p => p.LastName)
                .IsRequired();

            builder.Property(p => p.ShortName)
               .IsRequired();
        }
    }
}
