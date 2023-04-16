using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarysToyStore.DataAccess;

public class Order
{
	public int Id { get; set; }

	[Required]
	public int UserId { get; set; }

	[Required, Display]
	public OrderStatus OrderStatus { get; set; }

	[Display]
	public DateTime DateOrdered { get; set; }

	public User? User { get; set; }

	public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

	public decimal Cost
	{
		get
		{
			decimal totalCost = OrderLines.Sum(x => x.TotalPrice + x.TotalTax);
			return Math.Round(totalCost, 2);

		}
	}

	[NotMapped]
	public decimal Tax
	{
		get
		{
			decimal totalTax = OrderLines.Sum(x => x.TotalTax);
			return Math.Round(totalTax, 2);
		}
	}

	[NotMapped]
	public decimal Price
	{
		get
		{
			decimal totalPrice = OrderLines.Sum(x => x.TotalPrice * x.ProductQuantity);
			return Math.Round(totalPrice, 2);
		}
	}
}
