using KeyHouse.container;
using KeyHouse.Models.Entities;
using KeyHouse.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeyHouse.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(KeyHouseDB context)
        {
            _context = context;
        }
        private readonly KeyHouseDB _context;
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("DashBoard", "Admin");
            }
           
            else
            {
                List<Units> units = new UnitRepo(_context).GetAllUnits();
                return View(units);
            }

        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Unit(int id)
        {
            UnitRepo UnitRepository = new(_context);
            Units Unit = UnitRepository.GetUnitById(id);
            return View("Unit",Unit);
        }
    }
}
