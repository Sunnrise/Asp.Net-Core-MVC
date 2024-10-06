using StoreApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

//adding controllerviews for mvc, controller for api
builder.Services.AddControllersWithViews();

//adding razorpages for mvvm pattern without controller
builder.Services.AddRazorPages();

//Db extension registration
builder.Services.ConfigureDbContext(builder.Configuration);

//Session extension registration
builder.Services.ConfigureSession();

//Repository extension registration
builder.Services.ConfigureRepositoryRegistration();

//Service extension registration
builder.Services.ConfigureServiceRegistration();



//HttpContextAccessor IoC Regis.
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();


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

//Auto migrations extension registration
app.ConfigureAndCheckMigration();

app.Run();
