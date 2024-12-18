namespace KuaforYonetimSistemi.Models
{
    public class Employee
    {
        public int Id { get; set; } // Birincil anahtar
        public string Name { get; set; } // Çalışan adı
        public string Specialization { get; set; } // Uzmanlık alanı (ör. Saç Kesimi)
        public bool IsAvailable { get; set; } // Çalışanın uygunluk durumu
    }
}
