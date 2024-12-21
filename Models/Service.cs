using System;

namespace KuaforYonetimSistemi.Models
{
    /// <summary>
    /// Bir salonun sunduğu hizmetleri temsil eden tablo (Saç Kesimi, Boya vb.).
    /// </summary>
    public class Service
    {
        public int Id { get; set; }  // PK

        public string ServiceName { get; set; }  // Örnek: Saç Kesimi, Sakal, Boya...

        public TimeSpan Duration { get; set; }   // Hizmetin ortalama süresi

        public decimal Price { get; set; }       // Hizmetin ücreti

        // Hangi salonun hizmeti olduğunu gösteren FK
        public int SalonId { get; set; }
        public Salon Salon { get; set; }         // Navigation Property
    }
}
