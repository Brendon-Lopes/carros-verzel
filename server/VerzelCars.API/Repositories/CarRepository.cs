using Microsoft.EntityFrameworkCore;
using VerzelCars.API.Contexts;
using VerzelCars.API.DTOs.Car;
using VerzelCars.API.Models;

namespace VerzelCars.API.Repositories;

public class CarRepository : ICarRepository
{
    private readonly VerzelCarsContext _context;

    public CarRepository(VerzelCarsContext context)
    {
        _context = context;
    }

    public async Task<CreateCarResponse?> Create(CreateCarRequest car)
    {
        var findBrand = await _context.Brands.FirstOrDefaultAsync(b => b.BrandId == car.BrandId);
        if (findBrand == null) return null;

        var newCar = new Car
        {
            Name = car.Name,
            Model = car.Model,
            Year = car.Year,
            Price = car.Price,
            ImageUrl = car.ImageUrl,
            BrandId = car.BrandId,
        };

        var created = await _context.Cars.AddAsync(newCar);

        await _context.SaveChangesAsync();

        return new CreateCarResponse(created.Entity);
    }

    // public async Task<ICollection<Car>> FindAll(int page, int pageSize)
    // {
    //     return await _context.Cars
    //         .Skip((page - 1) * pageSize)
    //         .Take(pageSize)
    //         .ToListAsync();
    // }
}
