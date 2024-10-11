using KeyHouse.Models.Entities;
using KeyHouse.container;
using KeyHouse.Models.Entities;
using KeyHouse.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KeyHouse
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<KeyHouseDB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Local")));

            builder.Services.AddIdentity<Users, IdentityRole>().AddRoles<IdentityRole>().AddEntityFrameworkStores<KeyHouseDB>();
            var app = builder.Build();


            // Call the method to create roles within a scope
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await CreateRoles(services);
            }

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            await app.RunAsync();
            // Method to create roles
            async Task CreateRoles(IServiceProvider serviceProvider)
            {
                // Get RoleManager and UserManager services
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<Users>>();

                // List of roles to create
                string[] roleNames = { "Admin", "Users", "Agencies" };

                foreach (var roleName in roleNames)
                {
                    // Check if the role exists, and create if not
                    var roleExists = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                // Optionally: create a default admin user
                var adminEmail = "admin@gg.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);

                if (adminUser == null)
                {
                    var admin = new Admin
                    {
                        UserName = adminEmail,
                        Email = adminEmail
                    };

                    var createAdmin = await userManager.CreateAsync(admin, "Admin@123");

                    if (createAdmin.Succeeded)
                    {
                        // Add the admin user to the "Admin" role
                        await userManager.AddToRoleAsync(admin, "Admin");
                    }
                }
            }

        }
    }
}
