using FluentValidation;
using VerzelCars.API.DTOs.Authentication;

namespace VerzelCars.API.Services.Validations;

public class LoginValidation : AbstractValidator<CreateUserRequest>
{
    public LoginValidation()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
    }
}

