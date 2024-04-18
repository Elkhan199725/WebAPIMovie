using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIMovie.Business.DTOs.GenreDto;

public class GenreUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
}
