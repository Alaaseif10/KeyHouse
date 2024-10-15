using KeyHouse.container;
using KeyHouse.Migrations;
using KeyHouse.Models.Entities;
using KeyHouse.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using X.PagedList;
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
        public IActionResult Index(string category , string type , int area1=0 , int area2 = 0,int price1=0,int price2=0,  int? page=1 )
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

                List<Units> units = new UnitRepo(_context).GetAllUnits();

                // If category or type is selected, filter the units
                
                if (
                   ( !string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(type) )
                    || (area1 >0 && area2 >0) || (price1>0 && price2 >0)
                   )
                    units = new UnitRepo(_context).GetFilteredUnits(category, type,area1 ,area2, price1 ,price2 ); 

                else
                    units = new UnitRepo(_context).GetAllUnits();


                int pageNumber = page ?? 1;
                int pageSize = 8;

                // Use X.PagedList to paginate the data
                var pagedData = units.ToPagedList(pageNumber, pageSize);
                ViewBag.Units = pagedData;
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

        public IActionResult Unit(int id)
        {
            UnitRepo UnitRepository = new(_context);
            Units Unit = UnitRepository.GetUnitById(id);
            return View("Unit",Unit);
        }
    }
}
