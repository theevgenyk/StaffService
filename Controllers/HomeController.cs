using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeContext db;

        public HomeController(EmployeeContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InputIdForShowStaff()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<RedirectToActionResult> InputIdForShowStaff(Employee employee)
        {
            return RedirectToAction("ShowStaff", employee);
        }
       
        public async Task<IActionResult> ShowStaff(string companyId)
        {
            if (companyId == "0") return View(await db.Staff.ToListAsync());
            List<Employee> staff = new List<Employee>();
            foreach (var employee in db.Staff)
            {
                if (companyId == employee.CompanyId)
                {
                    staff.Add(employee);
                }
            }
            return View(staff);
        }
        
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            db.Staff.Add(employee);
            await db.SaveChangesAsync();
            ViewData["Message"] = "Сотрудник успешно добавлен!";
            ViewData["id"] = $"ID сотрудника = {employee.Id}";
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(Employee employee, int id)
        {
            db.Staff.Remove(await db.Staff.FindAsync(id));
            await db.SaveChangesAsync();
            ViewData["Message"] = "Сотрудник удалён";
            return View();
        }
        
        public IActionResult DeleteEmployee()
        {
            return View();
        }

        public IActionResult InputIdForChangeEmployee()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> InputIdForChangeEmployee(Employee employee)
        {
            return RedirectToAction("ChangeEmployee", employee);
        }
        
        public async Task<IActionResult> ChangeEmployee(int id)
       {
            Employee employee = await db.Staff.FirstOrDefaultAsync(p => p.Id == id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeEmployee(Employee employee)
        {
            db.Staff.Update(employee);
            await db.SaveChangesAsync();
            ViewData["Message"] = "Сотрудник изменён";
           // return RedirectToAction("Index");
           
           return View();
        }
    }
}