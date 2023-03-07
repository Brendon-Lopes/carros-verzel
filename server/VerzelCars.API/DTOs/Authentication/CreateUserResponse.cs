namespace VerzelCars.API.DTOs.Authentication;

public class CreateUserResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }

    public CreateUserResponse(CreateUserRequest user, string token)
    {
        Token = token;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
    }
}
