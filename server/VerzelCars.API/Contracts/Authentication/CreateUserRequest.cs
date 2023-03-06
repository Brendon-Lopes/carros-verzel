namespace VerzelCars.API.Contracts.Authentication;

public record CreateUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password);
