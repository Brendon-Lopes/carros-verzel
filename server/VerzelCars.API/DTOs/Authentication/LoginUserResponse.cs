using VerzelCars.API.Models;

namespace VerzelCars.API.DTOs.Authentication;

public class LoginUserResponse
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Role { get; }
    public string Token { get; }

    public LoginUserResponse(User user, string token)
    {
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
        Token = token;
        Role = user.Role;
    }
}
