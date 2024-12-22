using KuaforYonetimSistemi.Data;
using KuaforYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KuaforYonetimSistemi.Controllers
{
    /// <summary>
    /// Randevu (Appointment) yönetimi: alma, listeleme, onaylama vb.
    /// </summary>
    public class AppointmentController : Controller
    {
        private readonly KuaforContext _context;

        public AppointmentController(KuaforContext context)
        {
            _context = context;
        }

        // GET: /Appointment/MyAppointments
        // Kullanıcının kendi randevularını listeleyebileceği örnek aksiyon.
        public async Task<IActionResult> MyAppointments()
        {
            // Kimlik doğrulama varsa User.FindFirstValue(ClaimTypes.NameIdentifier) vb. alabilirsiniz
            var userId = "dummyUserId";  // Deneme amaçlı
            var appointments = await _context.Appointments
                .Include(a => a.Employee)
                .Include(a => a.Service)
                .Where(a => a.UserId == userId)
                .ToListAsync();

            return View(appointments);
        }

        // GET: /Appointment/Book
        public IActionResult Book()
        {
            // Randevu alma formu
            return View();
        }

        // POST: /Appointment/Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(int employeeId, int serviceId, DateTime dateTime)
        {
            // 1. İlgili çalışan var mı?
            var employee = await _context.Employees
                .Include(e => e.EmployeeSchedules)
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null)
            {
                ModelState.AddModelError("", "Seçilen çalışan bulunamadı.");
                return View();
            }

            // 2. Aynı saat aralığında randevu dolu mu?
            bool isAlreadyBooked = _context.Appointments
                .Any(a => a.EmployeeId == employeeId && a.AppointmentDate == dateTime);

            if (isAlreadyBooked)
            {
                ModelState.AddModelError("", "Bu saat dilimi dolu. Başka bir saat seçiniz.");
                return View();
            }

            // 3. Randevu oluştur
            var userId = "dummyUserId";  // Normalde Identity ile giriş yapan kullanıcının ID'si
            var appointment = new Appointment
            {
                UserId = userId,
                EmployeeId = employeeId,
                ServiceId = serviceId,
                AppointmentDate = dateTime,
                Status = "Pending" // Başlangıçta beklemede
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            // Kaydettikten sonra kendi randevular sayfasına yönlendirelim
            return RedirectToAction(nameof(MyAppointments));
        }

        // GET: /Appointment/Approve/5
        // Admin tarafında randevu onaylamak için
        public async Task<IActionResult> Approve(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return NotFound();

            appointment.Status = "Approved";
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
