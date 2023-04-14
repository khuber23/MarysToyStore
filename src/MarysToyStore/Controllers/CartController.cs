using MarysToyStore.DataAccess;
using MarysToyStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MarysToyStore.Controllers;

[Authorize, Route("cart")]
public class CartController : Controller
{
    private readonly AppConfig _appConfig;

    private readonly DataService _dataService;

    public CartController(IOptions<AppConfig> appConfigWrapper, DataContext dataContext)
    {
        _appConfig = appConfigWrapper.Value;
        _dataService = new DataService(dataContext);
    }
	private Order BuildOrder(int userId)
	{
		Order order = new Order();
		order.OrderLines = new List<OrderLine>();
		order.UserId = userId;

		List<CartItem> cartItems = _dataService.GetCartItems(userId);

		foreach (CartItem cartItem in cartItems)
		{
			OrderLine orderLine = new OrderLine();
			orderLine.ProductId = cartItem.ProductId;
			orderLine.Product = cartItem.Product;
			orderLine.ProductQuantity = cartItem.Quantity;
			orderLine.Price = cartItem.Product.Price;
			orderLine.Tax = cartItem.Product.Price * _appConfig.TaxRate;
			orderLine.Cost = orderLine.TotalPrice + orderLine.TotalTax;

			order.OrderLines.Add(orderLine);
		}

		return order;
	}

    [HttpGet("order-review")]
    public IActionResult OrderReview()
    {
        int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        Order order = this.BuildOrder(userId);
        return View(order);
    }

    [HttpPost("place-order")]
    public IActionResult PlaceOrder()
    {
        int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        Order order = this.BuildOrder(userId);
        order.OrderStatus = OrderStatus.Placed;
        order.DateOrdered = DateTime.Now;
        _dataService.AddOrder(order);
        foreach(CartItem cartItem in _dataService.GetCartItems(userId))
        {
            _dataService.DeleteCartItem(userId, cartItem.ProductId);
        }
        return RedirectToAction(nameof(OrderHistory));

    }

	[HttpGet("order-history")] 
    public IActionResult OrderHistory()
    {
		int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        List<Order> model = _dataService.GetOrders(userId);
		return View(model);
    }

    [HttpGet("view")]
    public IActionResult ViewCart()
    {
        int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        List<CartItem> model = _dataService.GetCartItems(userId);

        return View(model);
    }

    [HttpPost("add-to-cart/{id:int}")]
    public IActionResult AddToCart(int id)
    {
        int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        _dataService.AddCartItem(userId, id);

        return RedirectToAction(nameof(ViewCart));
    }

    [HttpGet("remove-from-cart/{id:int}")]
    public IActionResult RemoveFromCart(int id)
    {
        int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        _dataService.DeleteCartItem(userId, id);

        return RedirectToAction(nameof(ViewCart));
    }
}
