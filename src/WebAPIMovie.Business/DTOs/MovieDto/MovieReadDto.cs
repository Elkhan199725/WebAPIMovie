using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIMovie.Business.DTOs.MovieDto;

public class MovieReadDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public DateTime ReleaseDate { get; set; }
    public double SalePrice { get; set; }
    public bool IsActive { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }
    public List<string> GenreNames { get; set; }
}