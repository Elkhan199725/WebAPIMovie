using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMovie.Business.DTOs.MovieDto;

namespace WebAPIMovie.Business.DTOs.MovieDtoValidation;

public class MovieUpdateDtoValidator : AbstractValidator<MovieUpdateDto>
{
    public MovieUpdateDtoValidator()
    {
        RuleFor(m => m.Id)
            .GreaterThan(0).WithMessage("Movie ID must be greater than 0.");

        RuleFor(m => m.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Length(1, 100).WithMessage("Title must be between 1 and 100 characters long.");

        RuleFor(m => m.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(m => m.Rating)
            .InclusiveBetween(0, 10).WithMessage("Rating must be between 0 and 10.");

        RuleFor(m => m.CostPrice)
            .GreaterThan(0).WithMessage("Cost Price must be greater than 0.");

        RuleFor(m => m.SellPrice)
            .GreaterThan(0).WithMessage("Sell Price must be greater than 0.")
            .GreaterThan(m => m.CostPrice).WithMessage("Sell Price must be greater than Cost Price.");

        RuleFor(m => m.GenreIds)
            .NotEmpty().WithMessage("At least one genre must be selected.");

        RuleFor(m => m.ModifiedDate)
            .NotEmpty().WithMessage("Modified Date must be set.");
    }
}
