using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VerzelCars.API.DTOs.Brand;
using VerzelCars.API.Repositories;
using VerzelCars.API.Utils;

namespace VerzelCars.API.Controllers;

[ApiController]
[Route("api/brands")]
public class BrandController : ControllerBase
{
    private readonly IBrandRepository _brandRepository;

    public BrandController(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    [HttpPost]
    [Authorize(Policy = AuthorizationPolicies.RequireAdminRole)]
    public async Task<IActionResult> Create([FromBody] CreateBrandRequest brand)
    {
        var findBrand = await _brandRepository.FindBrandByName(brand.Name);

        if (findBrand != null) return Conflict(new { error = "Brand already exists" });

        var created = await _brandRepository.Create(brand);

        return CreatedAtAction(null, new CreateBrandResponse(created.BrandId, created.Name));
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> FindAll()
    {
        var brands = await _brandRepository.FindAll();

        return Ok(brands.Select(b => new FindAllBrandResponse(b.BrandId, b.Name)));
    }
}
