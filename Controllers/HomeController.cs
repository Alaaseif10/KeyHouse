using KeyHouse.container;
using KeyHouse.Models.Entities;
using KeyHouse.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static KeyHouse.Models.Enums;

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
                #region data
                ViewBag.PropertySellType = new SelectList(Enum.GetValues(typeof(PropertySellType)));
                ViewBag.PropertyCategory = new SelectList(Enum.GetValues(typeof(PropertyCategory)));
                ViewBag.PropertyType = new SelectList(Enum.GetValues(typeof(PropertyType)));
                var units = new UnitRepo(_context).GetAllUnits();
                ViewBag.Units = units;
                #endregion

                
                return View("Index");
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
    }
}
