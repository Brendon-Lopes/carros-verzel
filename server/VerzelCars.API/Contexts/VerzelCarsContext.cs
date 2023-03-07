using Microsoft.EntityFrameworkCore;
using VerzelCars.API.Models;

namespace VerzelCars.API.Contexts;

public class VerzelCarsContext : DbContext
{
    public VerzelCarsContext(DbContextOptions<VerzelCarsContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<User>().Property(u => u.UpdatedAt).HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

        modelBuilder.Entity<Car>().Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<Car>().Property(c => c.UpdatedAt).HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Car>().Property(c => c.Price).HasColumnType("decimal(18,2)");
    }
}
