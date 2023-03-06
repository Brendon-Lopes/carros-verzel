using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VerzelCars.API.Models;

public class Brand
{
    [Key]
    public Guid BrandId { get; set; }
    public string Name { get; set; } = null!;
    [InverseProperty("Brand")]
    public ICollection<Car>? Cars { get; set; }
}
