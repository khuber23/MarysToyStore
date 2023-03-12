using MarysToyStore.Models;
using MarysToyStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using MarysToyStore.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;

namespace MarysToyStore.Controllers;

[Authorize(Roles = "Admin")]
[Route("admin")]
public class AdminController : Controller
{
    private readonly AppConfig _appConfig;

    private readonly ILogger<AdminController> _logger;

    private readonly DataService _dataService;

    public AdminController(ILogger<AdminController> logger, IOptions<AppConfig> appConfigWrapper, DataContext dataContext)
    {
        _logger = logger;
        _appConfig = appConfigWrapper.Value;
        _dataService = new DataService(dataContext);
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
}
