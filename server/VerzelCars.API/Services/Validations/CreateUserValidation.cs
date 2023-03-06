using FluentValidation;
using VerzelCars.API.Contracts.Authentication;

namespace VerzelCars.API.Services.Validations;

public class CreateUserValidation : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidation()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required")
            .Length(2, 50).WithMessage("First name must be between 2 and 50 characters");

        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
            .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters");

        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is invalid");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
            .Length(6, 20).WithMessage("Password must be between 6 and 20 characters");
    }
}
