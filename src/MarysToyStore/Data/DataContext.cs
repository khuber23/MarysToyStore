using Microsoft.EntityFrameworkCore;

namespace MarysToyStore.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    public DbSet<Product> Products { get; set; }
}
