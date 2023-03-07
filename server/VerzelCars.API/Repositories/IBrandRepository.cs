using VerzelCars.API.DTOs.Brand;
using VerzelCars.API.Models;

namespace VerzelCars.API.Repositories;

public interface IBrandRepository
{
    Task<Brand> Create(CreateBrandRequest brand);
    Task<Brand?> FindBrandByName(string name);
    Task<ICollection<Brand>> FindAll();
}
