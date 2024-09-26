using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

//adding controllerviews for mvc, controller for api
builder.Services.AddControllersWithViews();

//database using declaration 
builder.Services.AddDbContext<RepositoryContext>(options=>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));
});

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
