using MarysToyStore.Models;
using MarysToyStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MarysToyStore.DataAccess;

namespace MarysToyStore.Controllers
{
	[Authorize(Roles = "Admin")]
	[Route("admin")]
	public class AdminController : Controller
	{
		private readonly IOptions<AppConfig> _appConfig;

		private readonly ILogger<AdminController> _logger;

		private readonly DataService _dataService;

		public AdminController(ILogger<AdminController> logger, IOptions<AppConfig> appConfigWrapper, DataContext dataContext)
		{
			_logger = logger;
			_appConfig = appConfigWrapper;
			_dataService = new DataService(dataContext);
		}

		[Route("productcategories")]
		public IActionResult ProductCategories()
		{
			List<ProductCategory> model = _dataService.GetProductCategories();
			return View(model);
        }

        [HttpGet("addproductcategory")]
        public IActionResult AddProductCategory()
        { return View(); }


        [HttpPost("addproductcategory")]
        public IActionResult AddProductCategory(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _dataService.AddProductCategory(productCategory);

            return RedirectToAction(nameof(ProductCategories));
        }

        [HttpGet("edit-productCategory/{id:int}")]
        public IActionResult EditProductCategory(int id)
        {
            ProductCategory model = _dataService.GetProductCategory(id);

            return View(model);
        }

        [HttpPost("edit-productCategory/{id:int}")]
        public IActionResult EditProductCategory(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _dataService.UpdateProductCategory(productCategory);

            return RedirectToAction(nameof(ProductCategories));
        }

        [Route("products")]
		public IActionResult Products()
		{
			List<Product> model = _dataService.GetProducts();

			return View(model);
		}

		[HttpGet("addproduct")]
		public IActionResult AddProduct()
		{
			ProductViewModel productViewModel = new()
			{
				Brands = _dataService.GetBrands()
			};

			return View(productViewModel);
		}


		[HttpPost("addproduct")]
		public IActionResult AddProduct(Product product)
		{
			if (!ModelState.IsValid)
			{
				ProductViewModel productViewModel = new()
				{
					Brands = _dataService.GetBrands()
				};

				return View(productViewModel);
			}

			_dataService.AddProduct(product);

			return RedirectToAction(nameof(Products));
		}

        [HttpGet("edit-product/{id:int}")]
        public IActionResult EditProduct(int id)
        {
            ProductViewModel productViewModel = new ProductViewModel();
			productViewModel.Brands = _dataService.GetBrands();
			productViewModel.Product = _dataService.GetProduct(id);
			return View(productViewModel);
        }

        [HttpPost("edit-product/{id:int}")]
        public IActionResult EditProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                productViewModel = new ProductViewModel();
                productViewModel.Brands = _dataService.GetBrands();
				return View(productViewModel);
            }

            _dataService.UpdateProduct(productViewModel);

            return RedirectToAction(nameof(Products));
        }

        [Route("brands")]
		public IActionResult Brands()
		{
			// Need logic to return the list of brands.
			List<Brand> model = _dataService.GetBrands();

			return View(model);
		}

		[HttpGet("addbrand")]
		public IActionResult AddBrand()
		{ return View(); }


		[HttpPost("addbrand")]
		public IActionResult AddBrand(Brand brand)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			_dataService.AddBrand(brand);

			return RedirectToAction(nameof(Brands));
		}

		[HttpGet("edit-brand/{id:int}")]
		public IActionResult EditBrand(int id)
		{
			Brand model = _dataService.GetBrand(id);

			return View(model);
		}

		[HttpPost("edit-brand/{id:int}")]
		public IActionResult EditBrand(Brand brand)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			_dataService.UpdateBrand(brand);

			return RedirectToAction(nameof(Brands));
		}
	}
}