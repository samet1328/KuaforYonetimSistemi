namespace KuaforYonetimSistemi.Models
{
    public class Service
    {
        public int Id { get; set; } // Birincil anahtar
        public string Name { get; set; } // Hizmet adı
        public decimal Price { get; set; } // Hizmet ücreti
        public TimeSpan Duration { get; set; } // Hizmetin süresi
    }
}
