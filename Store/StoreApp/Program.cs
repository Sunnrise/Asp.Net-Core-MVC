using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

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

//Repositories

builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();

//Services

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddSingleton<Cart>();

//AutoMapper Service Registration
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();



//for using static files(wwwroot)
app.UseStaticFiles();


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
