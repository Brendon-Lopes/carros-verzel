using CarModel = VerzelCars.API.Models.Car;

namespace VerzelCars.API.DTOs.Car;

public class FindAllCarsResponse
{
    public List<CreateCarResponse> Cars { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }

    public FindAllCarsResponse(ICollection<CarModel> cars, int currentPage, int totalPages)
    {
        CurrentPage = currentPage;
        TotalPages = totalPages;
        Cars = cars.Select(c => new CreateCarResponse(c)).ToList();
    }
}
