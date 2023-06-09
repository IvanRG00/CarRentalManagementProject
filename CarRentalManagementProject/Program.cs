using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CarRentalManagementProject.Data;
using CarRentalManagementProject.Areas.Identity.Data;
using CarRentalManagementProject.Models;
using Microsoft.CodeAnalysis;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthDbContextConnection' not found.");

builder.Services.AddDbContext<CarRentalManagementContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbContextConnection")));

builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


/* Роли за потребителите */


using (var scope = app.Services.CreateScope())
{ 
var roleManager =
        scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Manager", "Member" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}


using (var scope = app.Services.CreateScope())
{
    var userManager =
            scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

          string email="Admin@admin.com";  
          string password = "Parola1@";

    /*       Za manager 
     *      string email = "Manager@amanager.com";
            string password = "Parola1@"; */


    if (await userManager.FindByEmailAsync(email) ==null){
          var user = new ApplicationUser();
          user.UserName = email;
          user.Email = email;

          await userManager.CreateAsync(user, password);
          await userManager.AddToRoleAsync(user, "Admin"); /* "Manager" za manager */
      } 
        
}

app.MapRazorPages();

app.Run();
