using WebAPIMovie.Business.DTOs.GenreDto;

namespace WebAPIMovie.Business.DTOs.MovieDto;

public class MovieDetailedDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }
    public double SellPrice { get; set; }
    public List<GenreReadDto> Genres { get; set; }
}
