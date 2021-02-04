using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DSEU.Domain.Entities.Company;

namespace DSEU.Infrastructure.Persistence.Configurations.Company
{
    internal class ManagersAssistantConfiguration : IEntityTypeConfiguration<ManagersAssistant>
    {
        public void Configure(EntityTypeBuilder<ManagersAssistant> builder)
        {

            

            builder.Property(e => e.PreparesResolution)
              .IsRequired();


            builder.HasOne(p => p.Manager)
                .WithMany(p=>p.Assistants)
                .HasForeignKey(p => p.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Assistant)
                .WithMany()
                .HasForeignKey(p => p.AssistantId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }


    

}
