using VerzelCars.API.DTOs.Authentication;
using VerzelCars.API.Models;

namespace VerzelCars.API.Repositories;

public interface IUserRepository
{
    Task<string> CreateUser(CreateUserRequest user);
    Task<User?> FindUserByEmail(string email);
}
