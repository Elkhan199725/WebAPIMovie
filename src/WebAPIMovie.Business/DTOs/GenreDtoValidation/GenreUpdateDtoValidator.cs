using FluentValidation;
using WebAPIMovie.Business.DTOs.GenreDto;

namespace WebAPIMovie.Business.DTOs.GenreDtoValidation;

public class GenreUpdateDtoValidator : AbstractValidator<GenreUpdateDto>
{
    public GenreUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than zero.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

        // ModifiedDate is set to UTC now
    }
}
