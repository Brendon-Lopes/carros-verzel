using VerzelCars.API.Models;

namespace VerzelCars.API.Services.Authentication;

public interface IJwtGenerator
{
    string CreateToken(User user);
}
