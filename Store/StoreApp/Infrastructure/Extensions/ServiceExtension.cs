using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        //DbExtension
        public static void ConfigureDbContext(this IServiceCollection services, ConfigurationManager configuration)
        {
            //database using declaration 
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("sqlconnection"),
                b => b.MigrationsAssembly(nameof(StoreApp)));

                options.EnableSensitiveDataLogging(true);
            });
        }

        public static void ConfigureIndentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser,IdentityRole>(options=>
            {
                options.SignIn.RequireConfirmedAccount=false;
                options.User.RequireUniqueEmail=true;
                options.Password.RequireUppercase=false;
                options.Password.RequireLowercase=false;
                options.Password.RequireDigit=false;
                options.Password.RequiredLength=6;
            })
            .AddEntityFrameworkStores<RepositoryContext>();
        }

        //Session Extension 
        public static void ConfigureSession(this IServiceCollection services)
        {
            //Session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(9);
            });

            //IoC registration for Cart
            services.AddScoped<Cart>(c => SessionCart.GetCart(c));

        }

        //Repository Extension 
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }

        //Service Extension 
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IOrderService, OrderManager>();
        }

        public static void CongfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options=>
            {
                options.LowercaseUrls=true;
                options.AppendTrailingSlash=false;
            });

        }
    }
}