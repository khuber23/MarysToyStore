﻿using MarysToyStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarysToyStore.Controllers;

[Authorize, Route("cart")]
public class CartController : Controller
{
    private readonly DataService _dataService;

    public CartController(DataContext dataContext)
    {
        _dataService = new DataService(dataContext);
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
