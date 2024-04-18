using FluentValidation;
using WebAPIMovie.Business.DTOs.MovieDto;

namespace WebAPIMovie.Business.DTOs.MovieDtoValidation;

public class MovieReadDtoValidator : AbstractValidator<MovieReadDto>
{
    public MovieReadDtoValidator()
    {
        RuleFor(m => m.Id)
            .GreaterThan(0).WithMessage("Movie ID must be greater than 0.");

        RuleFor(m => m.Title)
            .NotEmpty().WithMessage("Title is required.");
    }
}