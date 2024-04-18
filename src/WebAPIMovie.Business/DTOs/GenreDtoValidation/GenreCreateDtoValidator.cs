using FluentValidation;
using WebAPIMovie.Business.DTOs.GenreDto;

namespace WebAPIMovie.Business.DTOs.GenreDtoValidation;

public class GenreCreateDtoValidator : AbstractValidator<GenreCreateDto>
{///
    public GenreCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

        // isActive is defaulted and usually does not need validation unless you have specific rules.

        // CreatedDate defaults to UTC now, which generally doesn't need to be validated as it is set by the system.
    }
}
