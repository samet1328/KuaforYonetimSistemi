using Microsoft.AspNetCore.Mvc;

namespace KuaforYonetimSistemi.Controllers.Api
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
