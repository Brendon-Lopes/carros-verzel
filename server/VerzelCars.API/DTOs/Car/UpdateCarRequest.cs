namespace VerzelCars.API.DTOs.Car;

public record UpdateCarRequest(
    string Name,
    string Model,
    int Year,
    decimal Price,
    string ImageUrl);
