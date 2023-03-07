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

    public async Task<FindAllCarsResponse> FindAll(int page, int pageSize)
    {
        var totalCars = await _context.Cars.CountAsync();

        var cars = await _context.Cars
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Include(c => c.Brand)
            .ToListAsync();

        var pageCount = (int)Math.Ceiling((double)totalCars / pageSize);

        return new FindAllCarsResponse(cars, page, pageCount);
    }

    public async Task<Car?> Update(UpdateCarRequest car, Guid id)
    {
        var findCar = _context.Cars.FirstOrDefault(c => c.CarId == id);

        if (findCar == null) return null;

        findCar.Name = car.Name;
        findCar.Model = car.Model;
        findCar.Year = car.Year;
        findCar.Price = car.Price;
        findCar.ImageUrl = car.ImageUrl;

        _context.Cars.Update(findCar);

        await _context.SaveChangesAsync();

        return findCar;
    }
}
