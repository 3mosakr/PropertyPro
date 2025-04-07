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
    public class UnitTypeConfiguration : IEntityTypeConfiguration<UnitType>
    {
        public void Configure(EntityTypeBuilder<UnitType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TypeName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();


            builder.ToTable("UnitTypes");
        }
    }
}
