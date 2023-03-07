namespace VerzelCars.API.DTOs.Car;

public record CreateCarRequest(
    string Name,
    string Model,
    int Year,
    decimal Price,
    string ImageUrl,
    Guid BrandId);
