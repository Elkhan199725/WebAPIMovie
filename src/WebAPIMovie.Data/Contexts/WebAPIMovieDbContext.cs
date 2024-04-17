using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMovie.Core.Models;

namespace WebAPIMovie.Data.Contexts;

public class WebAPIMovieDbContext : DbContext
{
    public WebAPIMovieDbContext(DbContextOptions<WebAPIMovieDbContext> options) : base(options) {}

    DbSet<Genre> Genres { get; set; }
    DbSet<Movie> Movies { get; set;}
}
