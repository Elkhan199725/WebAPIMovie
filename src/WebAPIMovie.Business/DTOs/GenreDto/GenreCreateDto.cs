using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIMovie.Business.DTOs.GenreDto;

public class GenreCreateDto
{
    public string Name { get; set; }
    public bool isActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}