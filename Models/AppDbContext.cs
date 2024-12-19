using Microsoft.EntityFrameworkCore; // Entity Framework Core için gerekli namespace
using KuaforYonetimSistemi.Models; // Proje içindeki modelleri kullanmamızı sağlar

namespace KuaforYonetimSistemi.Models
{
    // Veritabanı bağlamı sınıfı, Entity Framework Core ile veritabanı işlemlerini yönetir.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Constructor, veritabanı bağlamını yapılandırmak için gerekli ayarları alır.
        }

        // Veritabanındaki tabloları temsil eden DbSet tanımları
        public DbSet<Salon> Salons { get; set; } // Kuaför salonlarını temsil eder
        public DbSet<Employee> Employees { get; set; } // Çalışan bilgilerini temsil eder
        public DbSet<Service> Services { get; set; } // Hizmet bilgilerini temsil eder
        public DbSet<Appointment> Appointments { get; set; } // Randevu bilgilerini temsil eder
    }
}
