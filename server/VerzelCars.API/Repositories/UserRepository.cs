using Microsoft.EntityFrameworkCore;
using VerzelCars.API.Contexts;
using VerzelCars.API.DTOs.Authentication;
using VerzelCars.API.Models;
using VerzelCars.API.Services.Authentication;

namespace VerzelCars.API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly VerzelCarsContext _context;
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IPasswordHandler _passwordHandler;

    public UserRepository(VerzelCarsContext context, IJwtGenerator jwtGenerator, IPasswordHandler passwordHandler)
    {
        _context = context;
        _jwtGenerator = jwtGenerator;
        _passwordHandler = passwordHandler;
    }

    public async Task<User?> FindUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<CreateUserResponse> CreateUser(CreateUserRequest user)
    {
        var newUser = new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = _passwordHandler.HashPassword(user.Password),
            Role = "customer"
        };

        await _context.Users.AddAsync(newUser);

        var token = _jwtGenerator.CreateToken(newUser);

        await _context.SaveChangesAsync();

        return new CreateUserResponse(newUser, token);
    }

    public async Task<LoginUserResponse?> LoginUser(LoginUserRequest user)
    {
        var findUser = await FindUserByEmail(user.Email);

        if (findUser == null) return null;

        var isCorrect = _passwordHandler.VerifyPassword(user.Password, findUser.Password);

        if (!isCorrect) return null;

        var token = _jwtGenerator.CreateToken(findUser);

        return new LoginUserResponse(findUser, token);
    }
}
