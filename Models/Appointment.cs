using System;

namespace KuaforYonetimSistemi.Models
{
    /// <summary>
    /// Randevu bilgisini temsil eden tablo.
    /// </summary>
    public class Appointment
    {
        public int Id { get; set; }  // PK

        // Randevuyu alan kullanıcının ID'si (Identity ile string olabilir)
        public string UserId { get; set; }

        // Hangi çalışan ile randevu yapılıyor?
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        // Hangi hizmet için?
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        // Randevu tarihi ve saati
        public DateTime AppointmentDate { get; set; }

        // Randevunun durumu (Onaylandı, Beklemede, İptal vb.)
        public string Status { get; set; }
    }
}
