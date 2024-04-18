using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMovie.Core.Models;
using WebAPIMovie.Core.Repositories;
using WebAPIMovie.Data.Contexts;

namespace WebAPIMovie.Data.Repository.Implementations;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(WebAPIMovieDbContext context) : base(context)
    {
    }
}
