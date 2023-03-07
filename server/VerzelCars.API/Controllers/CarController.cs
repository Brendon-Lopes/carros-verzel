using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VerzelCars.API.DTOs.Car;
using VerzelCars.API.Repositories;
using VerzelCars.API.Utils;

namespace VerzelCars.API.Controllers;

[ApiController]
[Route("api/cars")]
[Authorize(Policy = AuthorizationPolicies.RequireAdminRole)]
public class CarController : ControllerBase
{
    private readonly ICarRepository _carRepository;

    public CarController(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCarRequest car)
    {
        var created = await _carRepository.Create(car);

        if (created == null) return BadRequest(new { error = "Brand not found" });

        return CreatedAtAction(null, created);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> FindAll(
        [FromQuery] string? order = "asc",
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 9)
    {
        var cars = await _carRepository.FindAll(page, pageSize, order!);

        return Ok(cars);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateCarRequest car, [FromRoute] Guid id)
    {
        var updated = await _carRepository.Update(car, id);

        if (updated == null) return BadRequest(new { error = "Car not found" });

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleted = await _carRepository.Delete(id);

        if (deleted == null) return NotFound(new { error = "Car not found" });

        return NoContent();
    }
}
