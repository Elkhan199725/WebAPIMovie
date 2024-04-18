using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIMovie.Business.DTOs.MovieDto;

public class MovieUpdateDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }
    public double CostPrice { get; set; }
    public double SellPrice { get; set; }
    public List<int> GenreIds { get; set; }
    public bool IsActive { get; set; }
    public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
}