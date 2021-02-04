using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Company;

namespace DSEU.Infrastructure.Persistence.Configurations.Company
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasIndex(p => p.Name);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Phone).IsRequired(false);
            builder.Property(e => e.Email).IsRequired(false).HasMaxLength(150);

            builder.HasOne(p => p.JobTitle)
                .WithMany(p => p.Employees)
                .HasForeignKey(p => p.JobTitleId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
