using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VerzelCars.API.Models;

public class Car
{
    [Key]
    public Guid CarId { get; set; }
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public int Year { get; set; }
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
    [ForeignKey("BrandId")]
    public Guid BrandId { get; set; }
    public Brand Brand { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
