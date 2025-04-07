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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasIndex(x => x.PhoneNumber)
                .IsUnique();

            builder.Property(x => x.FirstName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.FullName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(122)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

            builder.Property(x => x.Email)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60)
                .IsRequired();
            builder.Property(x => x.PhoneNumber)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(x => x.Address)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(x => x.Photo)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200)
                .IsRequired(false);

            // Relationships
            builder.HasOne(m => m.UserType)
                   .WithMany()
                   .HasForeignKey(m => m.UserTypeId)
                   .IsRequired();

            builder.HasMany(m => m.Favorites)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Ratings)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Post By
            builder.HasMany(m => m.Units)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            //builder.ToTable("Users");
        }
    }
}
