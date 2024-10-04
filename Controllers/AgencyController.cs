using KeyHouse.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using KeyHouse.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using static KeyHouse.Models.Enums;
using Microsoft.EntityFrameworkCore;
using KeyHouse.ModelView;

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



        BenefitServicesRepo serv = new BenefitServicesRepo();
        Locations loc = new Locations();
        public IActionResult Dashboard()
        {
            return View("AgencyDashBoard");
        }
        public IActionResult addProp()
        {
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
            return Json(loc.getcity(governmentId));
        }
        public JsonResult GetBlocks(int cityId)
        {
            return Json(loc.getblock(cityId));
        }

        public IActionResult SaveProp(UnitsDetailsModelView Unit) 
        {
            UnitRepo unit = new UnitRepo();
            if (ModelState.IsValid) {
                unit.InsertUnits(Unit);
                return View("AgencyDashBoard");
            }
            return View("index");
        }
    }
}
