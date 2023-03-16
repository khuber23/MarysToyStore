namespace MarysToyStore.DataAccess
{
	// Bridge table that establishes the many-to-many relationship between product and productCategory
	public class ProductCategoryProduct
	{
		public int ProductId { get; set; }

		public Product Product { get; set; }

		public int ProductCategoryId { get; set; }

		public ProductCategory ProductCategory { get; set; }
	}
}
