using Microsoft.AspNetCore.Mvc;
using VerzelCars.API.DTOs.Authentication;
using VerzelCars.API.Repositories;

namespace VerzelCars.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public AuthenticationController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest user)
    {
        var findEmail = await _userRepository.FindUserByEmail(user.Email);

        if (findEmail != null) return Conflict(new { error = "Email already exists" });

        var token = await _userRepository.CreateUser(user);

        return CreatedAtAction(null, new CreateUserResponse(user, token));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest user)
    {
        var loginResponse = await _userRepository.LoginUser(user);

        if (loginResponse == null) return BadRequest(new { error = "Invalid email or password" });

        return Ok(loginResponse);
    }
}
