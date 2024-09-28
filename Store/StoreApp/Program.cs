using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

//adding controllerviews for mvc, controller for api
builder.Services.AddControllersWithViews();

//database using declaration 
builder.Services.AddDbContext<RepositoryContext>(options=>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b=> b.MigrationsAssembly(nameof(StoreApp)));
});

builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();

var app = builder.Build();



//for using static files(wwwroot)
app.UseStaticFiles();


//for redirect http to https
app.UseHttpsRedirection();

//endpoints routes definition
app.UseRouting();

//controller route template
app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");
    // name:"default",
    // pattern:"{controller=Home}/{action=Index}/{id?}");

    //or like this
     

app.Run();
