using Microsoft.AspNetCore.Mvc; // MVC işlemleri için gerekli namespace
using KuaforYonetimSistemi.Models; // Proje içindeki modelleri ve veritabanı bağlamını kullanmak için gerekli

namespace KuaforYonetimSistemi.Controllers
{
    // Kuaför salonlarını yönetmek için bir controller
    public class SalonController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor ile veritabanı bağlamını (DbContext) alıyoruz
        public SalonController(AppDbContext context)
        {
            _context = context;
        }

        // Salonların listelendiği action
        public IActionResult Index()
        {
            var salons = _context.Salons.ToList(); // Tüm salonları veritabanından al
            return View(salons); // View'e salon listesini gönder
        }

        // Yeni bir salon oluşturma formunu gösteren action
        public IActionResult Create()
        {
            return View(); // Sadece View'i döndürür (kullanıcıya form gösterilir)
        }

        // Yeni bir salon kaydeden action (POST)
        [HttpPost]
        public IActionResult Create(Salon salon)
        {
            if (ModelState.IsValid)
            {
                _context.Salons.Add(salon); // Yeni salonu veritabanına ekle
                _context.SaveChanges(); // Değişiklikleri kaydet
                return RedirectToAction("Index"); // Salon listesine yönlendir
            }
            return View(salon); // Eğer doğrulama başarısızsa formu tekrar göster
        }
    }
}
