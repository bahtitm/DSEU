using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Entities.CoreEntities;
//using DSEU.Domain.Entities.Docflow;

namespace DSEU.Infrastructure.Persistence.Configurations.CoreEntities
{
    class RecipientConfiguration : IEntityTypeConfiguration<Recipient>
    {
        public void Configure(EntityTypeBuilder<Recipient> builder)
        {
            builder.HasIndex(e => e.Name);
            builder.HasIndex(e => e.Uid).IsUnique();

            builder.Property(p => p.RecipientType)
                .HasField("recipientType");

            builder.HasDiscriminator(p => p.RecipientType)
                .HasValue<BusinessUnit>(RecipientType.BusinessUnit)
                .HasValue<Department>(RecipientType.Department)
                .HasValue<Role>(RecipientType.Role)
                //history link
                //.HasValue<RegistrationGroup>(RecipientType.RegistrationGroup)
                .HasValue<SystemUser>(RecipientType.SystemUser)
                .HasValue<Employee>(RecipientType.Employee);
        }
    }
}
