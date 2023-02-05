using MarysToyStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MarysToyStore.Controllers;

public class HomeController : Controller
{
    private readonly AppConfig _appConfig;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IOptions<AppConfig> appConfigWrapper)
    {
        _logger = logger;
        _appConfig = appConfigWrapper.Value;
    }

    public IActionResult Index()
    {
        // Add data to the viewbag (making it accessible to the returned view).
        ViewBag.ApplicationName = "Mary's Toy Store";
        // return new ContentResult { Content = "Hello world!" };
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Product()
    {
        Product model = new()
        {
        Id = 5,
        Name = "Electric scooter",
        Description = "A cool, stylish scooter that won't start on fire!",
        Price = 18.99M
        };

        return View(model);
    }
}