using System.ComponentModel.DataAnnotations;

namespace MarysToyStore.DataAccess.Models
{
	public class Brand
	{
		public int Id { get; set; }

		[Required]
		public string? Name { get; set; }

		public List<Product>? Products { get; set; }
	}
}