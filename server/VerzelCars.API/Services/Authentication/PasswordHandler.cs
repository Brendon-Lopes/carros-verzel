namespace VerzelCars.API.Services.Authentication;

public class PasswordHandler : IPasswordHandler
{
    public string HashPassword(string password)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt();

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

        return hashedPassword;
    }

    public bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
