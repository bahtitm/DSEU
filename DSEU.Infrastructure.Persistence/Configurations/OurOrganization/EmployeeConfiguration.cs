using DSEU.Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.OurOrganization
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(p => p.JobTitle)
                .WithMany(p => p.Employees)
                .HasForeignKey(p => p.JobTitleId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
