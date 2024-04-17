using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIMovie.Core.Models;

public class Genre : BaseEntity
{
    public string Name { get; set; }

    // Navigation property for the many-to-many relationship
    public List<Movie>? Movies { get; set; }
}
