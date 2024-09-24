using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//adding controllerviews for mvc, controller for api
builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseHttpsRedirection();


//for redirect http to https
app.UseHttpsRedirection();

//endpoints routes definition
app.UseRouting();

//controller route template
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

    //or like this
    // "default","{controller=Home}/{action=Index}/{id?}");

app.Run();
