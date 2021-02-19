using DSEU.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.Commons
{
    internal class TerritorialUnitConfiguration : IEntityTypeConfiguration<TerritorialUnit>
    {
        public void Configure(EntityTypeBuilder<TerritorialUnit> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.HasIndex(p => p.Name);

            builder.HasOne(p => p.Type)
                .WithMany(p => p.TerritorialUnits)
                .HasForeignKey(prop => prop.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Parent)
                .WithMany(prop => prop.Childs)
                .HasForeignKey(prop => prop.ParentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
