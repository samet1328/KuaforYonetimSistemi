using System;

namespace KuaforYonetimSistemi.Models
{
    /// <summary>
    /// Çalışanın haftanın hangi günleri, hangi saat aralıklarında çalıştığını temsil eder.
    /// </summary>
    public class EmployeeSchedule
    {
        public int Id { get; set; }  // PK

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        // Haftanın günleri (Pazartesi=1, Salı=2, vb.)
        public int DayOfWeek { get; set; }

        // Çalışma başlangıç ve bitiş saatleri
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
    }
}
