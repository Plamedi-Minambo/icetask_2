using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using icetask2.Data;
using Microsoft.Extensions.DependencyInjection;
using icetask2.Views.Orders;


var builder = WebApplication.CreateBuilder(args);

// Configure database connections
var connectionString = builder.Configuration.GetConnectionString("icetask2Context")
    ?? throw new InvalidOperationException("Connection string 'icetask2Context' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CLVDCnn")));



builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Register application services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentProcessor, CreditCardPaymentProcessor>();
builder.Services.AddScoped<IOrderValidation, OrderValidation>();

// Add MVC support
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Enables serving static files (e.g., CSS, JS, images)

app.UseRouting();
app.UseAuthorization();

// Define endpoints
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();

app.Run();
