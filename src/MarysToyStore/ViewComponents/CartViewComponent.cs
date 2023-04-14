using MarysToyStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarysToyStore.ViewComponents;

public class CartViewComponent : ViewComponent
{
    private readonly DataService _dataService;

    public CartViewComponent(DataContext dataContext)
    {
        _dataService = new DataService(dataContext);
    }

    public IViewComponentResult Invoke()
    {
        List<CartItem> cartItems = new List<CartItem>();

        if (User.Identity.IsAuthenticated)
        {
            int userId = Convert.ToInt32(Request.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            cartItems = _dataService.GetCartItems(userId);
        }

        return View(cartItems);
    }
}
