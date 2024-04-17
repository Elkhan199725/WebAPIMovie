using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMovie.Core.Models;

namespace WebAPIMovie.Data.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");


        builder.HasKey(m => m.Id);

        // Configure the properties
        builder.Property(m => m.Id)
               .IsRequired()
               .ValueGeneratedOnAdd();

        builder.Property(m => m.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(m => m.Director)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(m => m.ReleaseDate)
               .IsRequired();

        builder.Property(m => m.Description)
               .IsRequired()
               .HasMaxLength(1000);

        builder.Property(m => m.Rating)
               .IsRequired()
               .HasColumnType("decimal(3, 2)");

        builder.Property(m => m.CostPrice)
               .IsRequired()
               .HasColumnType("decimal(10, 2)");

        builder.Property(m => m.SellPrice)
               .IsRequired()
               .HasColumnType("decimal(10, 2)");

        builder.HasIndex(m => m.Title).IsUnique();
    }
}
