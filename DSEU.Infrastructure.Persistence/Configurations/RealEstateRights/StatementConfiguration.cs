using DSEU.Domain.Entities.RealEstateRights;
using DSEU.Domain.Entities.SubjectsOfRights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.RealEstateRights
{
    class StatementConfiguration : IEntityTypeConfiguration<Statement>
    {
        public void Configure(EntityTypeBuilder<Statement> builder)
        {
            builder.Property(b => b.AcceptedDocuments).HasColumnType("jsonb");
            builder.Property(b => b.IssuedDocuments).HasColumnType("jsonb");

            builder.HasOne(p => p.Applicant)
                   .WithOne(prop => prop.Statement)
                   .HasForeignKey<Applicant>(prop => prop.StatementId)
                   .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(p => p.Representatives)
            //       .WithOne(prop => prop.Statement)
            //       .HasForeignKey(prop => prop.StatementId)
            //       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
