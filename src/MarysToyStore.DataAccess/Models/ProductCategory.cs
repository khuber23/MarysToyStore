using System.ComponentModel.DataAnnotations;

namespace MarysToyStore.DataAccess
{
	public class ProductCategory
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public List<ProductCategoryProduct>? ProductCategoryProducts { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
