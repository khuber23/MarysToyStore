using MarysToyStore.Models;
using MarysToyStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MarysToyStore.DataAccess;

namespace MarysToyStore.Controllers
{
	[Authorize]
	[AllowAnonymous]
	[Route("")]
	public class HomeController : Controller
	{
		private readonly AppConfig _appConfig;

		private readonly ILogger<HomeController> _logger;

		private readonly DataService _dataService;

		public HomeController(ILogger<HomeController> logger, IOptions<AppConfig> appConfigWrapper, DataContext dataContext)
		{
			_logger = logger;
			_appConfig = appConfigWrapper.Value;
			_dataService = new DataService(dataContext);
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
}