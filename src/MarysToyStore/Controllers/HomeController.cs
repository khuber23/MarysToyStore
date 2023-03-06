using MarysToyStore.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

namespace MarysToyStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly AppConfig _appConfig;

    public HomeController(ILogger<HomeController> logger, IOptions<AppConfig> appConfigWrapper)
    {
        _logger = logger;
        _appConfig = appConfigWrapper.Value;
    }

    public IActionResult Index()
    {
        // Add data to the viewbag (making it accessible to the returned view).
        ViewBag.ApplicationName = "Mary's Toy Store";
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Product()
    {
        Product model = new Product
        {
            Id = 5,
            Name = "Electric scooter",
            Description = "A cool, stylish scooter that won't start on fire!",
            Price = 18.99M
        };

        return View(model);
    }
}