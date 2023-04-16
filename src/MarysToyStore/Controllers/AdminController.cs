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

        [HttpGet]
        [Route("orderdetails/{orderId:int}")]
        public IActionResult OrderDetails(int orderId)
        {
            Order model = _dataService.GetOrder(orderId);
            return View(model);
        }

        [HttpPost]
        [Route("orderdetails/{orderId:int}")]
        public IActionResult OrderDetails(Order order)
        {
			if (!ModelState.IsValid)
			{
				return View(order);
			}
            _dataService.UpdateOrderStatus(order.Id, order.OrderStatus);
			return RedirectToAction(nameof(Orders));
		}

        [HttpGet("orders")]
        public IActionResult Orders()
        {
            List<Order> model = _dataService.GetOrders();
            return View(model);
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

        [HttpGet("delete-productCategory/{id:int}")]
        public IActionResult DeleteProductCategoryConfirm(int id)
        {
            return View(_dataService.GetProductCategory(id));
        }

        [HttpPost("delete-productCategory/{id:int}")]
        public IActionResult DeleteProductCategory(int id)
        {
            _dataService.DeleteProductCategory(id);

            return RedirectToAction(nameof(ProductCategories));
        }

        [HttpGet("restore-productCategory")]
        public IActionResult RestoreProductCategory()
        {
            return View(_dataService.GetDeletedProductCategories());
        }

        [HttpGet("restore-productCategory/{id:int}")]
        public IActionResult RestoreProductCategory(int id)
        {
            _dataService.RestoreProductCategory(id);
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
                Brands = _dataService.GetBrands(),
                AllProductCategories = _dataService.GetProductCategories()
			};

			return View(productViewModel);
		}


		[HttpPost("addproduct")]
		public IActionResult AddProduct(ProductViewModel productViewModel)
		{
            Product product = productViewModel.Product;
			if (!ModelState.IsValid)
			{
                productViewModel.Brands = _dataService.GetBrands();
                productViewModel.AllProductCategories = _dataService.GetProductCategories();
 

				return View(productViewModel);
			}
            if (productViewModel.SelectedProductCategoryIds != null)
            {
                productViewModel.Product.ProductCategoryProducts = new List<ProductCategoryProduct>();
                foreach (int productCategoryId in productViewModel.SelectedProductCategoryIds)
                {
                    productViewModel.Product.ProductCategoryProducts.Add(new ProductCategoryProduct { ProductCategoryId = productCategoryId });
                }
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
            productViewModel.AllProductCategories = _dataService.GetProductCategories();
            productViewModel.SelectedProductCategoryIds = new List<int>();
            foreach (ProductCategoryProduct pcp in productViewModel.Product.ProductCategoryProducts)
            {
                productViewModel.SelectedProductCategoryIds.Add(pcp.ProductCategoryId);
            }
            return View(productViewModel);
        }

        [HttpPost("edit-product/{id:int}")]
        public IActionResult EditProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                productViewModel.Brands = _dataService.GetBrands();
				productViewModel.Product = _dataService.GetProduct(productViewModel.Product.Id);
                Product dbProduct = _dataService.GetProduct(productViewModel.Product.Id);

                productViewModel.SelectedProductCategoryIds = new List<int>();
                foreach (ProductCategoryProduct pcp in dbProduct.ProductCategoryProducts)
                {
                    productViewModel.SelectedProductCategoryIds.Add(pcp.ProductCategoryId);
                }

                productViewModel.AllProductCategories = _dataService.GetProductCategories();
                return View(productViewModel);
            }

            if (productViewModel.SelectedProductCategoryIds != null)
            {
                productViewModel.Product.ProductCategoryProducts = new List<ProductCategoryProduct>();
                foreach (int productCategoryId in productViewModel.SelectedProductCategoryIds)
                {
                    productViewModel.Product.ProductCategoryProducts.Add(new ProductCategoryProduct { ProductCategoryId = productCategoryId });
                }
            }
            Product product = productViewModel.Product;
            _dataService.UpdateProduct(product);
            return RedirectToAction(nameof(Products));
        }

        [HttpGet("delete-product/{id:int}")]
        public IActionResult DeleteProductConfirm(int id)
        {
            return View(_dataService.GetProduct(id));
        }

        [HttpPost("delete-product/{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            _dataService.DeleteProduct(id);

            return RedirectToAction(nameof(Products));
        }

        [HttpGet("restore-product")]
        public IActionResult RestoreProduct()
        {
            return View(_dataService.GetDeletedProducts());
        }

        [HttpGet("restore-product/{id:int}")]
        public IActionResult RestoreProduct(int id)
        {
            _dataService.RestoreProduct(id);
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

        [HttpGet("delete-brand/{id:int}")]
        public IActionResult DeleteBrandConfirm(int id)
        {
            return View(_dataService.GetBrand(id));
        }

        [HttpPost("delete-brand/{id:int}")]
        public IActionResult DeleteBrand(int id)
        {
            _dataService.DeleteBrand(id);

            return RedirectToAction(nameof(Brands));
        }

        [HttpGet("restore-brand")]
        public IActionResult RestoreBrand()
		{		
			return View(_dataService.GetDeletedBrands());
		}

        [HttpGet("restore-brand/{id:int}")]
        public IActionResult RestoreBrand(int id)
		{
			_dataService.RestoreBrand(id);
            return RedirectToAction(nameof(Brands));
        }
    }
}