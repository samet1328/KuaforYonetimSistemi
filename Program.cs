using Microsoft.AspNetCore.Builder; // ASP.NET Core uygulamas� i�in gerekli yap�land�rma ara�lar�n� sa�lar
using Microsoft.EntityFrameworkCore; // Entity Framework Core ile veritaban� y�netimini kolayla�t�r�r
using Microsoft.Extensions.DependencyInjection; // Dependency Injection (ba��ml�l�k enjeksiyonu) mekanizmas�n� yap�land�r�r
using KuaforYonetimSistemi.Models; // Projeye ait veritaban� modellerini ve DbContext'i kullanmam�z� sa�lar

// ASP.NET Core uygulamas�n� ba�latmak ve yap�land�rmak i�in bir builder nesnesi olu�turuyoruz.
var builder = WebApplication.CreateBuilder(args);

// 1. MVC i�in gerekli servisleri ekliyoruz
builder.Services.AddControllersWithViews();
// Bu sat�r, uygulaman�n Model-View-Controller (MVC) yap�s�nda �al��aca��n� belirtir.
// Bu sayede Controller'lar ile View'lar aras�nda ba�lant� kurulur ve kullan�c� aray�z� sunulur.

// 2. Veritaban� ba�lant�s�n� yap�land�r�yoruz
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// "AppDbContext" s�n�f�n� kullanarak veritaban� i�lemlerini yap�land�r�yoruz.
// "DefaultConnection" ba�lant� dizesi, veritaban� bilgilerini appsettings.json dosyas�ndan al�r.
// SQL Server Express ile ileti�im kurarak veritaban� i�lemlerini ger�ekle�tirir.

var app = builder.Build(); // Web uygulamas�n� ba�latmak i�in bir uygulama nesnesi olu�turuyoruz.

// 3. Uygulaman�n �al��ma ortam�n� kontrol ediyoruz
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // E�er uygulama geli�tirme ortam�nda de�ilse (�rne�in, �retim ortam�nda),
    // bir hata meydana geldi�inde "/Home/Error" sayfas�na y�nlendirilir.
    app.UseHsts();
    // HTTP Strict Transport Security (HSTS) protokol�n� etkinle�tirerek g�venlik sa�lar.
}

app.UseHttpsRedirection();
// Gelen HTTP isteklerini otomatik olarak HTTPS'ye y�nlendirir. Bu, g�venli ba�lant� sa�lar.

app.UseStaticFiles();
// Statik dosyalar� (�rne�in, CSS, JavaScript, g�r�nt�ler) kullan�c�lara sunmak i�in bu middleware'i ekliyoruz.

app.UseRouting();
// URL'leri belirli controller ve action'lara y�nlendirmek i�in routing mekanizmas�n� etkinle�tiriyoruz.

app.UseAuthorization();
// Kullan�c�lar�n yetkilendirme mekanizmalar�n� kontrol etmek i�in kullan�l�r (�u anda bir kimlik do�rulama sistemi kurmad�k).

// 4. Varsay�lan rota yap�land�rmas�
app.MapControllerRoute(
    name: "default", // Rota i�in bir isim veriyoruz (iste�e ba�l�).
    pattern: "{controller=Salon}/{action=Index}/{id?}"
// Rota �ablonu:
// 1. E�er bir controller belirtilmezse "SalonController" kullan�l�r.
// 2. E�er bir action belirtilmezse "Index" action'� �a�r�l�r.
// 3. {id?} iste�e ba�l� bir parametredir (�rne�in, bir ��enin ID'si).
);

app.Run();
// Uygulamay� �al��t�r�r ve gelen HTTP isteklerini i�lemeye ba�lar.
