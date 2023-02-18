using Microsoft.EntityFrameworkCore;

namespace MarysToyStore.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Specifiy the seed data.
        modelBuilder.Entity<Product>().HasData(
                    new Product { Id = 1, Name = "Car", Description = "A toy car that goes really fast.", Price = 3.99m, ImagePath = "/bluecar.jpg" },
                    new Product { Id = 2, Name = "Ducks", Description = "Toy ducks that float.", Price = 10.99m, ImagePath = "/ducks.jpg" },
                    new Product { Id = 3, Name = "Legos", Description = "A toy to build your ideas.", Price = 25.99m, ImagePath = "/legos.jpg" },
                    new Product { Id = 4, Name = "Robot", Description = "An advanced toy that will make anybody happy.", Price = 15.99m, ImagePath = "/robot.jpg" },
                    new Product { Id = 5, Name = "Teddy", Description = "A soft bear that is comforting to touch.", Price = 29.99m, ImagePath = "/teddy.jpg" }
        );
    }

    public DbSet<Product> Products { get; set; }
}
