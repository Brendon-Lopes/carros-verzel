using FluentValidation;
using VerzelCars.API.DTOs.Car;

namespace VerzelCars.API.Services.Validations;

public class CreateCarValidation : AbstractValidator<CreateCarRequest>
{
    public CreateCarValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");

        RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required")
            .Length(2, 50).WithMessage("Model must be between 2 and 50 characters");

        RuleFor(x => x.Year).NotEmpty().WithMessage("Year is required");

        RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("ImageUrl is required");

        RuleFor(x => x.BrandId).NotEmpty().WithMessage("BrandId is required");
    }
}


