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
		private readonly IOptions<AppConfig> _appConfig;

		private readonly ILogger<HomeController> _logger;

		private readonly DataService _dataService;

		public HomeController(ILogger<HomeController> logger, IOptions<AppConfig> appConfigWrapper, DataContext dataContext)
		{
			_logger = logger;
			_appConfig = appConfigWrapper;
			_dataService = new DataService(dataContext);
		}

		[Route("")]
		public IActionResult Index(string sort, string filter)
		{
			//// Add data to the viewbag (making it accessible to the returned view).
			//ViewBag.ApplicationName = "Mary's Toy Store";
			//// return new ContentResult { Content = "Hello world!" };
			//return View();
            List<Product> model = _dataService.GetProducts();
            if (!String.IsNullOrEmpty(filter))
            {
                model = model
                    .Where(p => p.Name.ToLower().Contains(filter.ToLower())
                        || p.Description.ToLower().Contains(filter.ToLower()))
                    .ToList();
            }
            switch (sort)
            {
                case "name_desc":
                    model = model.OrderByDescending(x => x.Name).ToList();
                    break;
                default:
                    model = model.OrderBy(x => x.Name).ToList();
                    break;
            }
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sort) ? "name_desc" : "";
			switch (sort)
			{
				case "price_desc":
					model = model.OrderByDescending(x=>x.Price).ToList();
					break;
				case "price_asc":
					model = model.OrderBy(x => x.Price).ToList();
					break;

            }
            ViewData["PriceSortParm"] = sort == "price_asc" ? "price_desc" : "price_asc";
            ViewData["Filter"] = filter;
            return View(model);
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

		[Route("error")]
		public IActionResult Error()
		{
			return View();
		}
	}
}