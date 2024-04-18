using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMovie.Business.DTOs.MovieDto;

namespace WebAPIMovie.Business.DTOs.MovieDtoValidation;

public class MovieDetailedDtoValidator : AbstractValidator<MovieDetailedDto>
{
    public MovieDetailedDtoValidator()
    {
        RuleFor(m => m.Id)
            .GreaterThan(0).WithMessage("Movie ID must be greater than 0.");

        RuleFor(m => m.Title)
            .NotEmpty().WithMessage("Title is required.");
    }
}