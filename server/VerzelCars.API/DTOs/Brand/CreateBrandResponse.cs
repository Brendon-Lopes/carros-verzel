namespace VerzelCars.API.DTOs.Brand;

public class CreateBrandResponse
{
    public Guid BrandId { get; set; }
    public string Name { get; set; }

    public CreateBrandResponse(Guid brandId, string name)
    {
        BrandId = brandId;
        Name = name;
    }
}
