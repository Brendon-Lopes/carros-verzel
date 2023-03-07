using CarModel = VerzelCars.API.Models.Car;

namespace VerzelCars.API.DTOs.Car;

public class CreateCarResponse
{
    public Guid CarId { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public Guid BrandId { get; set; }
    public string BrandName { get; set; }

    public CreateCarResponse(CarModel car)
    {
        CarId = car.CarId;
        Name = car.Name;
        Model = car.Model;
        Year = car.Year;
        Price = car.Price;
        ImageUrl = car.ImageUrl;
        BrandId = car.BrandId;
        BrandName = car.Brand.Name;
    }
}
