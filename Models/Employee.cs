using System.Collections.Generic;

namespace KuaforYonetimSistemi.Models
{
    /// <summary>
    /// Salonda çalışan berber/kuaför bilgisini temsil eden tablo.
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }  // PK

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Expertise { get; set; }  // Uzmanlık (ör: saç, sakal, boya...)

        // Hangi salonda çalışıyor (FK)?
        public int SalonId { get; set; }
        public Salon Salon { get; set; }

        // Navigation Properties
        public List<EmployeeSchedule> EmployeeSchedules { get; set; }  // Çalışma gün-saat bilgisi
        public List<Appointment> Appointments { get; set; }           // Çalışanın randevuları
    }
}
