nusing System;
using System.Collections.Generic;

namespace KuaforYonetimSistemi.Models
{
    /// <summary>
    /// Bir kuaför/berber salonunu temsil eden tablo (entity).
    /// </summary>
    public class Salon
    {
        public int Id { get; set; }  // Birincil anahtar (PK)

        public string SalonName { get; set; }  // Salonun adı

        public string Address { get; set; }     // Salonun adresi

        // Salonun açılış ve kapanış saatleri
        public TimeSpan WorkingHoursStart { get; set; }
        public TimeSpan WorkingHoursEnd { get; set; }

        // Navigation Properties
        public List<Service> Services { get; set; }       // Salonun sunduğu hizmetler
        public List<Employee> Employees { get; set; }     // Salonda çalışan personeller
    }
}
