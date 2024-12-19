using Microsoft.AspNetCore.Builder; // ASP.NET Core uygulamasý için gerekli yapýlandýrma araçlarýný saðlar
using Microsoft.EntityFrameworkCore; // Entity Framework Core ile veritabaný yönetimini kolaylaþtýrýr
using Microsoft.Extensions.DependencyInjection; // Dependency Injection (baðýmlýlýk enjeksiyonu) mekanizmasýný yapýlandýrýr
using KuaforYonetimSistemi.Models; // Projeye ait veritabaný modellerini ve DbContext'i kullanmamýzý saðlar

// ASP.NET Core uygulamasýný baþlatmak ve yapýlandýrmak için bir builder nesnesi oluþturuyoruz.
var builder = WebApplication.CreateBuilder(args);

// 1. MVC için gerekli servisleri ekliyoruz
builder.Services.AddControllersWithViews();
// Bu satýr, uygulamanýn Model-View-Controller (MVC) yapýsýnda çalýþacaðýný belirtir.
// Bu sayede Controller'lar ile View'lar arasýnda baðlantý kurulur ve kullanýcý arayüzü sunulur.

// 2. Veritabaný baðlantýsýný yapýlandýrýyoruz
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// "AppDbContext" sýnýfýný kullanarak veritabaný iþlemlerini yapýlandýrýyoruz.
// "DefaultConnection" baðlantý dizesi, veritabaný bilgilerini appsettings.json dosyasýndan alýr.
// SQL Server Express ile iletiþim kurarak veritabaný iþlemlerini gerçekleþtirir.

var app = builder.Build(); // Web uygulamasýný baþlatmak için bir uygulama nesnesi oluþturuyoruz.

// 3. Uygulamanýn çalýþma ortamýný kontrol ediyoruz
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Eðer uygulama geliþtirme ortamýnda deðilse (örneðin, üretim ortamýnda),
    // bir hata meydana geldiðinde "/Home/Error" sayfasýna yönlendirilir.
    app.UseHsts();
    // HTTP Strict Transport Security (HSTS) protokolünü etkinleþtirerek güvenlik saðlar.
}

app.UseHttpsRedirection();
// Gelen HTTP isteklerini otomatik olarak HTTPS'ye yönlendirir. Bu, güvenli baðlantý saðlar.

app.UseStaticFiles();
// Statik dosyalarý (örneðin, CSS, JavaScript, görüntüler) kullanýcýlara sunmak için bu middleware'i ekliyoruz.

app.UseRouting();
// URL'leri belirli controller ve action'lara yönlendirmek için routing mekanizmasýný etkinleþtiriyoruz.

app.UseAuthorization();
// Kullanýcýlarýn yetkilendirme mekanizmalarýný kontrol etmek için kullanýlýr (þu anda bir kimlik doðrulama sistemi kurmadýk).

// 4. Varsayýlan rota yapýlandýrmasý
app.MapControllerRoute(
    name: "default", // Rota için bir isim veriyoruz (isteðe baðlý).
    pattern: "{controller=Salon}/{action=Index}/{id?}"
// Rota þablonu:
// 1. Eðer bir controller belirtilmezse "SalonController" kullanýlýr.
// 2. Eðer bir action belirtilmezse "Index" action'ý çaðrýlýr.
// 3. {id?} isteðe baðlý bir parametredir (örneðin, bir öðenin ID'si).
);

app.Run();
// Uygulamayý çalýþtýrýr ve gelen HTTP isteklerini iþlemeye baþlar.
