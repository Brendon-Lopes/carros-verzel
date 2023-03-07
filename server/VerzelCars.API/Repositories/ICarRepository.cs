using VerzelCars.API.DTOs.Car;
using VerzelCars.API.Models;

namespace VerzelCars.API.Repositories;

public interface ICarRepository
{
    Task<CreateCarResponse?> Create(CreateCarRequest car);
    Task<FindAllCarsResponse> FindAll(int page, int pageSize);
    Task<Car?> Update(UpdateCarRequest car, Guid id);
}

