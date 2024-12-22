using KuaforYonetimSistemi.Data;
using KuaforYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KuaforYonetimSistemi.Controllers
{
    /// <summary>
    /// Salon CRUD (ekleme, listeleme, güncelleme, silme) işlemlerini yönetir.
    /// Yalnızca Admin rolü erişebilmesi için [Authorize(Roles="Admin")] ekleyebilirsiniz.
    /// </summary>
    public class SalonController : Controller
    {
        private readonly KuaforContext _context;

        public SalonController(KuaforContext context)
        {
            _context = context;
        }

        // GET: /Salon/Index
        public async Task<IActionResult> Index()
        {
            // Tüm salonları liste halinde veritabanından çekerek View'e gönderiyoruz
            var salons = await _context.Salons.ToListAsync();
            return View(salons);
        }

        // GET: /Salon/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // ID değerine göre salona ait bilgileri (hizmetler, çalışanlar vb.) çekiyoruz
            var salon = await _context.Salons
                .Include(s => s.Services)
                .Include(s => s.Employees)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (salon == null)
                return NotFound();

            return View(salon);
        }

        // GET: /Salon/Create
        public IActionResult Create()
        {
            // Yeni salon ekleme formu
            return View();
        }

        // POST: /Salon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Salon salon)
        {
            if (ModelState.IsValid)
            {
                // Formdan gelen salon verilerini veritabanına ekliyoruz
                _context.Salons.Add(salon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salon);
        }

        // GET: /Salon/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var salon = await _context.Salons.FindAsync(id);
            if (salon == null)
                return NotFound();

            return View(salon);
        }

        // POST: /Salon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Salon salon)
        {
            if (id != salon.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                // Salon bilgilerini güncelliyoruz
                _context.Salons.Update(salon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salon);
        }

        // GET: /Salon/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var salon = await _context.Salons.FindAsync(id);
            if (salon == null)
                return NotFound();

            return View(salon);
        }

        // POST: /Salon/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salon = await _context.Salons.FindAsync(id);
            if (salon != null)
            {
                _context.Salons.Remove(salon);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
