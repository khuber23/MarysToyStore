﻿using System.ComponentModel.DataAnnotations;

namespace MarysToyStore.DataAccess
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

		public List<ProductCategoryProduct>? ProductCategoryProducts { get; set; }

        [Required]
        public bool IsArchived { get; set; }

        public List<CartItem>? CartItems { get; set; }

		public List<OrderLine>? OrderLines { get; set; }
    }
}
