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

        var response = await _userRepository.CreateUser(user);

        return CreatedAtAction(null, response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest user)
    {
        var response = await _userRepository.LoginUser(user);

        if (response == null) return BadRequest(new { error = "Invalid email or password" });

        return Ok(response);
    }
}
