using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMovie.Core.Models;
using WebAPIMovie.Data.Configurations;

namespace WebAPIMovie.Data.Contexts;

public class WebAPIMovieDbContext : DbContext
{
    public WebAPIMovieDbContext(DbContextOptions<WebAPIMovieDbContext> options) : base(options) {}

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfiguration());

        // Many-to-many relationship configuration
        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Genres)
            .WithMany(g => g.Movies)
            .UsingEntity<Dictionary<string, object>>(
                "MovieGenre", // Table name for the join table
                j => j.HasOne<Genre>()
                    .WithMany()
                    .HasForeignKey("GenreId")
                    .OnDelete(DeleteBehavior.Restrict), // Prevent deletion of Genre if it's part of any MovieGenre association
                j => j.HasOne<Movie>()
                    .WithMany()
                    .HasForeignKey("MovieId")
                    .OnDelete(DeleteBehavior.Cascade)  // Cascade delete for Movie when deleting from MovieGenre
            );
    }

}
