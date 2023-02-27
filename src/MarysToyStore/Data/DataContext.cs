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

<<<<<<< HEAD
        // Define the relationship between the Products and the Brands.
        modelBuilder.Entity<Product>()
            .HasOne(x => x.Brand)
            .WithMany(x => x.Products)
            .IsRequired();

        // Specifiy the brand seed data.
        modelBuilder.Entity<Brand>().HasData(
            new Brand { Id = 1, Name = "Mattel" },
            new Brand { Id = 2, Name = "Fisher Price" },
            new Brand { Id = 3, Name = "Hot Wheels" }
        );

        // Specifiy the product seed data.
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Car", Description = "A toy car that goes really fast.", Price = 3.99m, ImagePath = "/bluecar.jpg", BrandId = 3 },
            new Product { Id = 2, Name = "Ducks", Description = "Toy ducks that float.", Price = 10.99m, ImagePath = "/ducks.jpg", BrandId = 1 },
            new Product { Id = 3, Name = "Legos", Description = "A toy to build your ideas.", Price = 25.99m, ImagePath = "/legos.jpg", BrandId = 1 },
            new Product { Id = 4, Name = "Robot", Description = "An advanced toy that will make anybody happy.", Price = 15.99m, ImagePath = "/robot.jpg", BrandId = 1 },
            new Product { Id = 5, Name = "Teddy", Description = "A soft bear that is comforting to touch.", Price = 29.99m, ImagePath = "/teddy.jpg", BrandId = 2 }
        );
    }

    public DbSet<Brand> Brands { get; set; }

=======
        // Specifiy the seed data.
        modelBuilder.Entity<Product>().HasData(
                    new Product { Id = 1, Name = "Car", Description = "A toy car that goes really fast.", Price = 3.99m, ImagePath = "/bluecar.jpg" },
                    new Product { Id = 2, Name = "Ducks", Description = "Toy ducks that float.", Price = 10.99m, ImagePath = "/ducks.jpg" },
                    new Product { Id = 3, Name = "Legos", Description = "A toy to build your ideas.", Price = 25.99m, ImagePath = "/legos.jpg" },
                    new Product { Id = 4, Name = "Robot", Description = "An advanced toy that will make anybody happy.", Price = 15.99m, ImagePath = "/robot.jpg" },
                    new Product { Id = 5, Name = "Teddy", Description = "A soft bear that is comforting to touch.", Price = 29.99m, ImagePath = "/teddy.jpg" }
        );
    }

>>>>>>> b5f555990d3dc0429685036e54860cd504192632
    public DbSet<Product> Products { get; set; }
}
