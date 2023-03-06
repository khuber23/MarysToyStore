using System.ComponentModel.DataAnnotations;

namespace MarysToyStore.Models
{
    public class ProductViewModel
    {
        public Product? Product { get; set; }

        public List<Brand>? Brands { get; set; }
    }
}
