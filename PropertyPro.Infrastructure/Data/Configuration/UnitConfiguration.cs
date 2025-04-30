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
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(u => u.Id);

            
            builder.Property(u => u.Title)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.Description)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(4000)
                .IsRequired();

            //builder.Ignore(u => u.Address);
            builder.Property(u => u.Address)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(300)
                .IsRequired(false);
                 

            builder.Property(u => u.StreetName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(u => u.CompoundName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(u => u.ResourceLink)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(u => u.DeveloperPortfolio)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150)
                .IsRequired(false);


            // Relationships

            // posted by
            builder.HasOne(u => u.User)
                .WithMany(m => m.Units)
                .HasForeignKey(u => u.UserId);

            builder.HasOne(u => u.Category)
                .WithMany()
                .HasForeignKey(u => u.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UnitType)
                .WithMany()
                .HasForeignKey(u => u.UnitTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.SaleType)
                .WithMany()
                .HasForeignKey(u => u.SaleTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Governorate)
                .WithMany()
                .HasForeignKey(u => u.GovernorateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.City)
                .WithMany()
                .HasForeignKey(u => u.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Area)
                .WithMany()
                .HasForeignKey(u => u.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Favorites)
                .WithOne(f => f.Unit)
                .HasForeignKey(f => f.UnitId);

            builder.HasMany(u => u.Ratings)
                .WithOne(r => r.Unit)
                .HasForeignKey(r => r.UnitId);

            builder.HasMany(u => u.Comments)
                .WithOne(c => c.Unit)
                .HasForeignKey(c => c.UnitId);

            builder.HasMany(u => u.Images)
                .WithOne()
                .HasForeignKey(i => i.UnitId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);


            builder.ToTable(tb => tb.HasTrigger("trg_UpdateAddress"));
            builder.ToTable("Units");
        }
    }
}
