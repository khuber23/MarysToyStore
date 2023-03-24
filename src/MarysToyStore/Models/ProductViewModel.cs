using MarysToyStore.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace MarysToyStore.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public List<Brand>? Brands { get; set; }

        public List<ProductCategory>? AllProductCategories { get; set; }

        [Display(Name = "Product Categories")]
        public List<int> SelectedProductCategoryIds { get; set; }
    }
}
