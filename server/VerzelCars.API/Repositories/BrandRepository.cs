using Microsoft.EntityFrameworkCore;
using VerzelCars.API.Contexts;
using VerzelCars.API.DTOs.Brand;
using VerzelCars.API.Models;

namespace VerzelCars.API.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly VerzelCarsContext _context;

    public BrandRepository(VerzelCarsContext context)
    {
        _context = context;
    }

    public async Task<Brand> Create(CreateBrandRequest brand)
    {
        var newBrand = new Brand
        {
            Name = brand.Name,
        };

        var created = await _context.Brands.AddAsync(newBrand);

        await _context.SaveChangesAsync();

        return created.Entity;
    }

    public async Task<Brand?> FindBrandByName(string name)
    {
        return await _context.Brands.FirstOrDefaultAsync(b => b.Name == name);
    }
}
