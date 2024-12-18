namespace KuaforYonetimSistemi.Models
{
    public class Appointment
    {
        public int Id { get; set; } // Birincil anahtar
        public DateTime AppointmentDate { get; set; } // Randevu tarihi
        public int SalonId { get; set; } // İlgili salonun ID'si
        public Salon Salon { get; set; } // Salon nesnesi
        public int EmployeeId { get; set; } // Çalışan ID'si
        public Employee Employee { get; set; } // Çalışan nesnesi
        public int ServiceId { get; set; } // Hizmet ID'si
        public Service Service { get; set; } // Hizmet nesnesi
    }
}
