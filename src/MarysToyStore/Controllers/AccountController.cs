using MarysToyStore.DataAccess.Data;
using MarysToyStore.Models;
using MarysToyStore.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
		[Route("register")]
		public IActionResult Register()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost("register")]
		[Route("register")]
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

			PasswordHasher<string> passwordHasher = new();

			User user = new()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				EmailAddress = model.EmailAddress,
				PasswordHash = passwordHasher.HashPassword(null, model.Password)
			};

			_dataService.AddUser(user);

			return RedirectToAction(nameof(Login));
		}

		[AllowAnonymous]
		[HttpGet("sign-in")]
		[Route("sign-in")]
		public IActionResult Login()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost("sign-in")]
		[Route("sign-in")]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel, string? returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			User user = _dataService.GetUser(loginViewModel.EmailAddress);

			if (user == null)
			{
				// Set email address not registered error message.
				ModelState.AddModelError("Error", "An account does not exist with that email address.");

				return View();
			}

			PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
			PasswordVerificationResult passwordVerificationResult =
				passwordHasher.VerifyHashedPassword(null, user.PasswordHash, loginViewModel.Password);

			if (passwordVerificationResult == PasswordVerificationResult.Failed)
			{
				// Set invalid password error message.
				ModelState.AddModelError("Error", "Invalid password.");

				return View();
			}

			// Add the user's ID (NameIdentifier), first name and role
			// to the claims that will be put in the cookie.
			var claims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
					new Claim(ClaimTypes.Name, user.FirstName),
					new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
				};

			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties { };

			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity),
				authProperties);

			if (string.IsNullOrEmpty(returnUrl))
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				return Redirect(returnUrl);
			}
		}

		[Route("sign-out"), Authorize]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(
				CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction("Index", "Home");
		}

		[AllowAnonymous]
		[Route("access-denied")]
		public IActionResult AccessDenied()
		{
			return View();
		}
	}