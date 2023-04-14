using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarysToyStore.DataAccess;

public class OrderLine
{
	public int Id { get; set; }

	[Required]
	public int OrderId { get; set; }

	[Required]
	public int ProductId { get; set; }

	[Required]
	public int ProductQuantity { get; set; }

	[Required]
	public decimal Price { get; set; }

	[Required]
	public decimal Tax { get; set; }

	[Required]
	public decimal Cost { get; set; }

	public Order? Order { get; set; }

	public Product? Product { get; set; }

	[NotMapped]
	public decimal TotalTax
	{
		get
		{
			decimal totalTax = this.Tax * this.ProductQuantity;
			Math.Round(totalTax, 2);
			return totalTax;
		}
	}

	[NotMapped]
	public decimal TotalPrice
	{
		get
		{
			decimal totalPrice = this.Price * this.ProductQuantity;
			Math.Round(totalPrice, 2);
			return totalPrice;
		}
	}
}
