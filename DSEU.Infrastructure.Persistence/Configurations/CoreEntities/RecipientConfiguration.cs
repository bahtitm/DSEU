using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations
{
    class RecipientConfiguration : IEntityTypeConfiguration<Recipient>
    {
        public void Configure(EntityTypeBuilder<Recipient> builder)
        {
            //builder.Property(p => p.Name).IsRequired();
            //builder.HasIndex(p => p.Name);
            //builder.HasIndex(p => p.Description);

            //builder.Property(p => p.RecipientType)
            //    .HasField("recipientType");

            //builder.HasDiscriminator(p => p.RecipientType)
            //   .HasValue<Role>(RecipientType.Role)
            //   .HasValue<SystemUser>(RecipientType.SystemUser)
            //   .HasValue<Employee>(RecipientType.Employee);
        }
    }
}
