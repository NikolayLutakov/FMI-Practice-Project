namespace QuizSystemWeb.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using QuizSystemWeb.Data;
    using QuizSystemWeb.Data.Entities;
    using System;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public const string AreaName = "Admin";

        public const string AdministratorRoleName = "Administrator";

        public static IApplicationBuilder PrepareDatabase(
           this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedAdministrator(services);
            SeedUser(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var adminRole = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(adminRole);

                    const string adminEmail = "admin@admin.com";

                    const string adminPassword = "123456";

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FullName = "Admin"

                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, adminRole.Name);

                })
                .GetAwaiter()
                .GetResult();
        }


        private static void SeedUser(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();

            Task
              .Run(async () =>
              {
                  const string userEmail = "test@test.com";

                  if (await userManager.FindByEmailAsync(userEmail) != null)
                  {
                      return;
                  }

                  const string userPassword = "123456";

                  var user = new User
                  {
                      Email = userEmail,
                      UserName = userEmail,
                      FullName = "TestUser"

                  };

                  await userManager.CreateAsync(user, userPassword);


              })
              .GetAwaiter()
              .GetResult();
        }
    }
}
