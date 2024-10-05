using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

//adding controllerviews for mvc, controller for api
builder.Services.AddControllersWithViews();

//adding razorpages for mvvm pattern without controller
builder.Services.AddRazorPages();

//database using declaration 
builder.Services.AddDbContext<RepositoryContext>(options=>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b=> b.MigrationsAssembly(nameof(StoreApp)));
});

//Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options=>
{
    options.Cookie.Name="StoreApp.Session";
    options.IdleTimeout=TimeSpan.FromMinutes(9);
});

//HttpContextAccessor IoC Regis.
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

//Repositories
builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();

//Services
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

//IoC registration for Cart
builder.Services.AddScoped<Cart>(c=> SessionCart.GetCart(c));

//AutoMapper Service Registration
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

//for using static files(wwwroot)
app.UseStaticFiles();

//for using session
app.UseSession();

//for redirect http to https
app.UseHttpsRedirection();

//endpoints routes definition
app.UseRouting();

//for areas
app.UseEndpoints(end=>
{
    //admin route
    _ = end.MapAreaControllerRoute(
            name: "Admin",
            areaName: "Admin",
            pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
        );
    //base route
    _ = end.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    _ = end.MapRazorPages();
});
app.Run();
