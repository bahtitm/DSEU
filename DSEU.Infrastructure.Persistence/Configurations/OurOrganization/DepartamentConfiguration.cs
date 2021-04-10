﻿using DSEU.Domain.Entities.OurOrganization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSEU.Infrastructure.Persistence.Configurations.OurOrganization
{
    public class DepartamentConfiguration : IEntityTypeConfiguration<Departament>
    {
        public void Configure(EntityTypeBuilder<Departament> builder)
        {
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(p => p.Agency)
                .WithMany(p => p.Departaments)
                .HasForeignKey(p => p.AgencyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}