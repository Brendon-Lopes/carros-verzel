namespace VerzelCars.API.DTOs.Authentication;

public record CreateUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password);
