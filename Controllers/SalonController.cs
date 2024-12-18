using Microsoft.AspNetCore.Mvc;
using KuaforYonetimSistemi.Models;

namespace KuaforYonetimSistemi.Controllers
{
    public class SalonController : Controller
    {
        private readonly AppDbContext _context;

        public SalonController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var salons = _context.Salons.ToList();
            return View(salons);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Salon salon)
        {
            if (ModelState.IsValid)
            {
                _context.Salons.Add(salon);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salon);
        }
    }
}
