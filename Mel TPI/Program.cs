using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mel_TPI.Data;
using Mel_TPI.Areas.Identity.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Mel_TPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("Mel_TPIContextConnection") ?? throw new InvalidOperationException("Connection string 'Mel_TPIContextConnection' not found.");

            builder.Services.AddDbContext<Mel_TPIContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<Mel_TPIUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<Mel_TPIContext>();
         
            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddHealthChecks();
            builder.Services.AddRazorPages();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            var app = builder.Build();

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
            app.UseAuthentication(); ;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();


            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "Student" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Mel_TPIUser>>();
                string Aemail = "admin@aiteesmusicstudio.com";
                string Apassword = "Admin123$";

                if (await userManager.FindByEmailAsync(Aemail) == null)
                {
                    var user = new Mel_TPIUser();
                    user.UserName = Aemail;
                    user.Email = Aemail;
                    user.FirstName = "Admin";
                    user.LastName = "Account";

                    await userManager.CreateAsync(user, Apassword);
                    await userManager.AddToRoleAsync(user, "Admin");
                    
                }
            }
            app.Run();

        }
    }
}

