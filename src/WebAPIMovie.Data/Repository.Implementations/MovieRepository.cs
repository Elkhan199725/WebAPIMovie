using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMovie.Core.Models;
using WebAPIMovie.Core.Repositories;
using WebAPIMovie.Data.Contexts;

namespace WebAPIMovie.Data.Repository.Implementations;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(WebAPIMovieDbContext context) : base(context)
    {
    }
}
