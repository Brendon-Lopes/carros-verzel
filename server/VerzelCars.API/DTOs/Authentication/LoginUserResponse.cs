using VerzelCars.API.Models;

namespace VerzelCars.API.DTOs.Authentication;

public class LoginUserResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }

    public LoginUserResponse(User user, string token)
    {
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
        Token = token;
    }
}
