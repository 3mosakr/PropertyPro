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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CityName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();


            builder.HasMany(c => c.Areas)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId);

            builder.ToTable("Cities");
        }
    }
}
