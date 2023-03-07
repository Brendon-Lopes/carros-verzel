using VerzelCars.API.DTOs.Authentication;
using VerzelCars.API.Models;

namespace VerzelCars.API.Repositories;

public interface IUserRepository
{
    Task<CreateUserResponse> CreateUser(CreateUserRequest user);
    Task<LoginUserResponse?> LoginUser(LoginUserRequest user);
    Task<User?> FindUserByEmail(string email);
}
