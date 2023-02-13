using MarysToyStore.Models;
using MarysToyStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MarysToyStore.Controllers;

[Route("")]
public class HomeController : Controller
{
    private readonly AppConfig _appConfig;

    private readonly ILogger<HomeController> _logger;

    private readonly DataService _dataService;

    public HomeController(ILogger<HomeController> logger, IOptions<AppConfig> appConfigWrapper)
    {
        _logger = logger;
        _appConfig = appConfigWrapper.Value;
        _dataService = new DataService();
    }

    [Route("")]
    public IActionResult Index()
    {
        // Add data to the viewbag (making it accessible to the returned view).
        ViewBag.ApplicationName = "Mary's Toy Store";
        // return new ContentResult { Content = "Hello world!" };
        return View();
    }

    [Route("about")]
    public IActionResult About()
    {
        return View();
    }

    [Route("product/{id:int}")]
    public IActionResult Product(int id)
    {
        Product model = _dataService.GetProduct(id);

        return View(model);
    }

    [Route("products")]
    public IActionResult Products()
    {
        List<Product> model = _dataService.GetProducts();

        return View(model);
    }

    [Route("error")]
    public IActionResult Error()
    {
        return View();
    }
}