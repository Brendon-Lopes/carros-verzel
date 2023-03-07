using FluentValidation;
using VerzelCars.API.DTOs.Brand;

namespace VerzelCars.API.Services.Validations;

public class CreateBrandValidation : AbstractValidator<CreateBrandRequest>
{
    public CreateBrandValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");
    }
}

