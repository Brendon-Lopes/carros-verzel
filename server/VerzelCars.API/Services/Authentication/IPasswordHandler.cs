namespace VerzelCars.API.Services.Authentication;

public interface IPasswordHandler
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hash);
}
