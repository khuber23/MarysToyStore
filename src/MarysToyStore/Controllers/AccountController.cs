using MarysToyStore.Data;
using MarysToyStore.Models;
using MarysToyStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarysToyStore.Controllers;

[Authorize]
[Route("")]
public class AccountController : Controller
{
    private readonly DataService _dataService;

    public AccountController(DataContext dataContext)
    {
        // Instantiate an instance of the data service.
        _dataService = new DataService(dataContext);
    }

    [AllowAnonymous]
    [HttpGet("register")]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}

		User existingUser = _dataService.GetUser(model.EmailAddress);
		if (existingUser != null)
		{
			// Set email address already in use error message.
			ModelState.AddModelError("Error", "An account already exists with that email address.");

			return View();
		}

		PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

		User user = new User()
		{
			FirstName = model.FirstName,
			LastName = model.LastName,
			EmailAddress = model.EmailAddress,
			PasswordHash = passwordHasher.HashPassword(null, model.Password)
		};

		_dataService.AddUser(user);

		return RedirectToAction(nameof(Register));
	}
}
