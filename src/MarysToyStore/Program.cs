global using MarysToyStore;
global using MarysToyStore.Models;
global using MarysToyStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using MarysToyStore.Services;
using Serilog.Events;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration)
	.CreateLogger();

// Use Serilog when setting up the host instead of its own logger
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Deserializes the AppConfig section and injects the resulting object - making it available to the rest of our application.
builder.Services.Configure<AppConfig>(builder.Configuration.GetSection("AppConfig"));

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/sign-in";
        options.LogoutPath = "/sign-out";
        options.AccessDeniedPath = "/access-denied";
        options.Cookie.Name = "UserAuth";
        options.ExpireTimeSpan = TimeSpan.FromDays(2);
        options.SlidingExpiration = true;
    });

// Add USPS Service to DI.
builder.Services.AddSingleton<UspsService>(new UspsService(
	builder.Configuration.GetValue<string>("UspsAddressVerificationUrl"),
	builder.Configuration.GetValue<string>("UspsToken")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

try
{
	Log.Information("Mary's Toy Store is starting...");
	app.Run();
}
catch (Exception ex)
{
	Log.Fatal(ex, "The program terminated unexpectedly.");
}
finally
{
	Log.Information("Mary's Toy Store is stopping...");
	Log.CloseAndFlush();
}