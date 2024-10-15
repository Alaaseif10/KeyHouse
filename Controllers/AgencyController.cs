using KeyHouse.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using KeyHouse.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using static KeyHouse.Models.Enums;
using Microsoft.EntityFrameworkCore;
using KeyHouse.ModelView;
using KeyHouse.container;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting.Server;

namespace KeyHouse.Controllers
{
    public class AgencyController : Controller
    {
        private readonly KeyHouseDB _context;
        SignInManager<Users> _signInManager;

        public AgencyController(KeyHouseDB context, SignInManager<Users> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public IActionResult Dashboard()
        {
            UnitRepo unit = new UnitRepo(_context);
            var agency = _signInManager.UserManager.Users.FirstOrDefault() as Agencies;
            var props = unit.getAllUnitsByAgency(agency.Id);
            return View("AgencyDashBoard", props);
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
            ViewBag.Services = serv.getServices();
            #endregion
            return View("AddProp");
        }
        public IActionResult SaveProp(UnitsDetailsModelView Unit)
        {
            UnitRepo unit = new UnitRepo(_context);
            if (ModelState.IsValid)
            {
                var result = _signInManager.UserManager.Users.FirstOrDefault() as Agencies;
                unit.InsertUnits(Unit, result);
                return RedirectToAction("Dashboard");
            }
            return View("addProp");
        }
        public IActionResult deleteProp(int PropId)
        {
            UnitRepo unit = new UnitRepo(_context);
            unit.DeleteUnits(PropId);
            return RedirectToAction("Dashboard");
        }
        public IActionResult editProp(int unitId)
        {
            UnitRepo unit = new UnitRepo(_context);
            Locations loc = new Locations(_context);
            BenefitServicesRepo serv = new BenefitServicesRepo(_context);
            ViewBag.Services = serv.getServices();
            ViewBag.Governments = loc.GetGovernments();
            UnitsEditDetailsModelView oldProp = unit.GetUnitByIdDashboard(unitId);
            ViewBag.SelectedServices = oldProp.SelectedServices;
            return View("editProp", oldProp);
        }
        public IActionResult saveAfterEdit(int propId, UnitsEditDetailsModelView UnitAfterEdit)
        {
            UnitRepo unit = new UnitRepo(_context);
            if (ModelState.IsValid)
            {
                unit.EditUnits(propId, UnitAfterEdit);


                return RedirectToAction("Dashboard");
            }
            return View("editProp", UnitAfterEdit);
        }
        public IActionResult UpdatePropertyStatus(int propId, int status)
        {
            UnitRepo unit = new UnitRepo(_context);
            unit.UpdateUnitStatus(propId, status);
            return Json(new { success = true, message = "Property status updated successfully." });
        }
        public IActionResult GetCities(int governmentId)
        {
            Locations loc = new Locations(_context);
            return Json(loc.getcity(governmentId));
        }
        public IActionResult GetBlocks(int cityId)
        {
            Locations loc = new Locations(_context);
            return Json(loc.getblock(cityId));
        }
        public IActionResult DeleteImage(string imagePath)
        {
            string fullPath = $"wwwroot{imagePath}";
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            UnitRepo unit = new UnitRepo(_context);
            unit.deleteImg(imagePath);
            return Json(new { success = true, message = "Image deleted successfully." });
        }
    }
}
