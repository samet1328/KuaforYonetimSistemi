using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using KuaforYonetimSistemi.Models;

var scope = app.Services.CreateScope();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

// Admin ve �ye rolleri olup olmad���n� kontrol et, yoksa olu�tur
if (!await roleManager.RoleExistsAsync("Admin"))
{
    await roleManager.CreateAsync(new IdentityRole("Admin"));
}
if (!await roleManager.RoleExistsAsync("Member"))
{
    await roleManager.CreateAsync(new IdentityRole("Member"));
}

// Varsay�lan Admin kullan�c� olu�turmak isterseniz
string adminEmail = "x@sakarya.edu.tr";
string adminPassword = "sau";

var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
if (existingAdmin == null)
{
    var adminUser = new ApplicationUser
    {
        UserName = adminEmail,
        Email = adminEmail,
        EmailConfirmed = true
    };

    var result = await userManager.CreateAsync(adminUser, adminPassword);
    if (result.Succeeded)
    {
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}
