namespace VerzelCars.API.DTOs.Brand;

public class FindAllBrandResponse
{
    public Guid BrandId { get; set; }
    public string Name { get; set; }

    public FindAllBrandResponse(Guid brandId, string name)
    {
        BrandId = brandId;
        Name = name;
    }
}
