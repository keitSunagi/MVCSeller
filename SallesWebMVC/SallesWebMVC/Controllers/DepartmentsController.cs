using Microsoft.AspNetCore.Mvc;
using SallesWebMVC.Models;
using System.Collections.Generic;

namespace SallesWebMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departments = new List<Department>();

            departments.Add(new Department { Id = 2, Name = "Fashion" });
            departments.Add(new Department { Id = 5, Name = "Eletronics" });
            departments.Add(new Department { Id = 8, Name = "Technology" });

            return View(departments);
        }
    }
}
