using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Company;
//using DSEU.Domain.Entities.Docflow;

namespace DSEU.Infrastructure.Persistence.Configurations.Company
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            

            builder.Property(e => e.Name)
                .IsRequired();

            builder.HasIndex(p => p.Name);

            builder.HasIndex(e => new { e.BusinessUnitId, e.Code }).IsUnique();

            builder.HasOne(p => p.BusinessUnit)
                .WithMany(p => p.Departments)
                .HasForeignKey(p => p.BusinessUnitId)
                .OnDelete(DeleteBehavior.Restrict);
            //todo histroy link
            //builder.HasMany<CaseFile>()
            //    .WithOne(p => p.Department)
            //    .HasForeignKey(p => p.DepartmentId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Manager)
                   .WithMany()
                   .HasForeignKey(p => p.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.HeadOffice)
               .WithMany()
               .HasForeignKey(p => p.HeadOfficeId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
