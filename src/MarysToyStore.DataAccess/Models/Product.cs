using System.ComponentModel.DataAnnotations;

namespace MarysToyStore.DataAccess.Models
{
	public class Product
	{
		public int Id { get; set; }


		[Required]
		public string? Name { get; set; }


		[Required]
		[MinLength(20, ErrorMessage = "The description must be longer than 20 characters.")]
		[DataType(DataType.MultilineText)]
		public string? Description { get; set; }

		[Required]
		[Range(.01, 1000000)]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		public string? ImagePath { get; set; } = "no-product-image.jpg";


		[Required]
		public int? BrandId { get; set; }

		public Brand? Brand { get; set; }
	}
}
