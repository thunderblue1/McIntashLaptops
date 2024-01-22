using McIntashLaptops.Models;
using McIntashLaptops.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using McIntashLaptops.Areas.Identity.Data;
using Stripe;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient<ILaptopDataService, LaptopDAO>();
builder.Services.AddTransient<ICheckoutService, CheckoutDAO>();
builder.Services.AddTransient<ISecurity, SecurityService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Data protection services
builder.Services.AddDataProtection();
builder.Services.AddScoped<SecurityService>();

builder.Services.AddScoped<ShoppingCartService>();

//Add Identity
//builder.Services.AddIdentity<UserModel, IdentityRole>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();;
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using(var scope = app.Services.CreateScope())
{
    ShoppingCartService.laptopDAO = scope.ServiceProvider.GetRequiredService<ILaptopDataService>();
    ShoppingCartService.checkoutDAO = scope.ServiceProvider.GetRequiredService<ICheckoutService>();
}

//Stripe
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();


app.Run();