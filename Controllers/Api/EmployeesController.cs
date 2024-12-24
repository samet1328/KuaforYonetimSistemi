using BarberShopManagement.Data;
using BarberShopManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using KuaforYonetimSistemi.Models;

namespace BarberShopManagement.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly BarberShopContext _context;

        public EmployeesController(BarberShopContext context)
        {
            _context = context;
        }

        // GET: /api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            // Tüm çalışanları LINQ ile çekiyor ve JSON olarak dönüyoruz
            var employees = await _context.Employees
                .Include(e => e.Salon)
                .ToListAsync();
            return Ok(employees);
        }

        // GET: /api/employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Salon)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // GET: /api/employees/byexpertise/Saç
        [HttpGet("byexpertise/{expertise}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByExpertise(string expertise)
        {
            // LINQ sorgusu ile uzmanlık alanına göre çalışan listesi
            var employees = await _context.Employees
                .Where(e => e.Expertise.Contains(expertise))
                .ToListAsync();

            if (!employees.Any())
            {
                return NotFound("Bu uzmanlık alanında çalışan bulunamadı.");
            }
            return Ok(employees);
        }

        // POST: /api/employees
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        // PUT: /api/employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employees.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: /api/employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
