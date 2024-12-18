namespace KuaforYonetimSistemi.Models
{
    public class Salon
    {
        public int Id { get; set; } // Birincil anahtar
        public string Name { get; set; } // Salon adı
        public string Address { get; set; } // Salon adresi
        public string WorkingHours { get; set; } // Çalışma saatleri (ör. 09:00 - 20:00)
    }
}
