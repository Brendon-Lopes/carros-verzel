namespace VerzelCars.API.DTOs.Authentication;

public class CreateUserResponse
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Role { get; } = "customer";
    public string Token { get; }

    public CreateUserResponse(CreateUserRequest user, string token)
    {
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
        Token = token;
    }
}
