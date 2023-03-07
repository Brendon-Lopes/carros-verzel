using Microsoft.Data.SqlClient;
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

    public async Task<FindAllCarsResponse> FindAll(
        int page,
        int pageSize,
        string order,
        string name,
        string brandName)
    {
        var nameLowerCase = name.ToLower();
        var cars = _context.Cars;

        var orderedCars = order == "asc"
            ? cars.OrderBy(c => c.Price)
            : cars.OrderByDescending(c => c.Price);

        var filteredCars = orderedCars
            .Where(c => c.Name.ToLower().Contains(nameLowerCase)
                || c.Model.ToLower().Contains(nameLowerCase)
                || c.Brand.Name.ToLower().Contains(nameLowerCase))
            .Where(c => brandName != "" ? c.Brand.Name.ToLower() == brandName.ToLower() : true)
            .Include(c => c.Brand);

        var totalCars = await filteredCars.CountAsync();

        var carsWithPagination = await filteredCars
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var pageCount = (int)Math.Ceiling((double)totalCars / pageSize);

        return new FindAllCarsResponse(carsWithPagination, page, pageCount);
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
        findCar.UpdatedAt = DateTime.UtcNow;

        _context.Cars.Update(findCar);

        await _context.SaveChangesAsync();

        return findCar;
    }

    public async Task<Car?> Delete(Guid id)
    {
        var findCar = _context.Cars.FirstOrDefault(c => c.CarId == id);

        if (findCar == null) return null;

        var removed = _context.Cars.Remove(findCar);

        await _context.SaveChangesAsync();

        return removed.Entity;
    }
}
