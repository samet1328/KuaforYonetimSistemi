namespace KuaforYonetimSistemi.Models
{
    // Salon bilgilerini temsil eden model
    public class Salon
    {
        public int Id { get; set; } // Birincil anahtar (Primary Key)
        public string Name { get; set; } // Salonun adı
        public string Address { get; set; } // Salonun adresi
        public string WorkingHours { get; set; } // Salonun çalışma saatleri (örneğin, 09:00 - 20:00)
    }
}
