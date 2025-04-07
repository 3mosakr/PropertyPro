using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyPro.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Infrastructure.Data.Configuration
{
    public class GovernorateConfiguration : IEntityTypeConfiguration<Governorate>
    {
        public void Configure(EntityTypeBuilder<Governorate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.GovernorateName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60)
                .IsRequired();


            builder.HasMany(c => c.Citys)
                .WithOne(cy => cy.Governorate)
                .HasForeignKey(cy => cy.GovernorateId);

            builder.ToTable("Governorates");
        }
    }
}
