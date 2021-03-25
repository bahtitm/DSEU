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
            builder.HasIndex(p => new { p.Name, p.ParentId ,p.TypeName}).IsUnique(); 
        }
    }
}
