using KeyHouse.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using KeyHouse.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using static KeyHouse.Models.Enums;
using Microsoft.EntityFrameworkCore;
using KeyHouse.ModelView;
using KeyHouse.container;
using Microsoft.AspNetCore.Identity;

namespace KeyHouse.Controllers
{
    public class AgencyController : Controller
    {
        //    public IActionResult Registeration()
        //    {
        //        return View("Registration");
        //    }

        //    [HttpPost]
        //    public  IActionResult SaveAgencyData(AgencyUserModelView AgencyData) {
        //        if (ModelState.IsValid)
        //        {
        //            if (AgencyData.logo != null && AgencyData.logo.Length > 0)
        //            {
        //                AgencyRepo agency = new AgencyRepo();
        //                agency.InsertAgencyAndUser(AgencyData);
        //                return View("index");
        //            }
        //        }
        //        return View("AgencyDashBoard");
        //    }

        private readonly KeyHouseDB _context;
        SignInManager<Users> _signInManager;

        public AgencyController(KeyHouseDB context,SignInManager<Users> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }


        public IActionResult Dashboard()
        {
            return View("AgencyDashBoard");
        }
        public IActionResult addProp()
        {
            Locations loc = new Locations(_context);
            BenefitServicesRepo serv = new BenefitServicesRepo(_context);
            #region data
            ViewBag.PropertySellType = new SelectList(Enum.GetValues(typeof(PropertySellType)));
            ViewBag.PropertyCategory = new SelectList(Enum.GetValues(typeof(PropertyCategory)));
            ViewBag.PropertyType = new SelectList(Enum.GetValues(typeof(PropertyType)));
            ViewBag.Under_constracting_Status = new SelectList(Enum.GetValues(typeof(Under_constracting_Status)));
            ViewBag.Governments = loc.GetGovernments();
            Console.WriteLine(ViewBag.Governments);
            ViewBag.Services = serv.getServices();
            #endregion
            return View("AddProp");
        }
        public JsonResult GetCities(int governmentId)
        {
            Locations loc = new Locations(_context);
            return Json(loc.getcity(governmentId));
        }
        public JsonResult GetBlocks(int cityId)
        {
            Locations loc = new Locations(_context);
            return Json(loc.getblock(cityId));
        }
        public IActionResult SaveProp(UnitsDetailsModelView Unit) 
        {
            UnitRepo unit = new UnitRepo(_context);
            if (ModelState.IsValid) {
                var result = _signInManager.UserManager.Users.FirstOrDefault() as Agencies;
                unit.InsertUnits(Unit, result);
                return View("AgencyDashBoard");
            }
            return View("index");
        }
    }
}
