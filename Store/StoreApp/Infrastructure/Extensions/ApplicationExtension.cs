using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

        }


        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedUICultures("tr-TR")
                    .AddSupportedUICultures("tr-TR")
                    .SetDefaultCulture("tr-TR");
            });

        }
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "admin+123456";

            //User manager
            UserManager<IdentityUser> userManager =
            app.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //Role manager
            RoleManager<IdentityRole> roleManager =
            app.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email = "alperengunes.eng@gmail.com",
                    PhoneNumber = "50212135445",
                    UserName = adminUser,
                };
                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                    throw new Exception("Admin creation was failed!!!");

                var roleResult = await userManager.AddToRolesAsync(user,roleManager.Roles.Select(r=> r.Name).ToList());

                if (!roleResult.Succeeded)
                    throw new Exception("System have problems with role definition for admin");
            }
        }
    }
}