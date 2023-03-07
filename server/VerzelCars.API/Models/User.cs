using System.ComponentModel.DataAnnotations;

namespace VerzelCars.API.Models;

public class User
{
    [Key]
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
