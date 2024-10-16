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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;

namespace KeyHouse.Controllers
{
    [Authorize(Roles = "Agencies")]
    public class AgencyController : Controller
    {
        private readonly KeyHouseDB _context;
        SignInManager<Users> _signInManager;
        UserManager<Users> _userManager;
        public AgencyController(KeyHouseDB context, UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Dashboard()
        {
            UnitRepo unit = new UnitRepo(_context);
            if (_signInManager.IsSignedIn(User))
            {
                var currentUser = await _userManager.GetUserAsync(User) as Agencies;
                // Access properties of currentUser here
                var props = unit.getAllUnitsByAgency(currentUser.Id);
                return View("AgencyDashBoard", props);
            }
            return RedirectToAction("Index", "Home");


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
        public async Task<IActionResult> SaveProp(UnitsDetailsModelView Unit)
        {
            UnitRepo unit = new UnitRepo(_context);
            if (ModelState.IsValid)
            {
                if (_signInManager.IsSignedIn(User))
                {
                    Agencies currentUser = await _userManager.GetUserAsync(User) as Agencies;
                    // Access properties of currentUser here
                    //var result = _signInManager.UserManager.Users.FirstOrDefault() as Agencies;
                    unit.InsertUnits(Unit, currentUser);
                    return RedirectToAction("Dashboard");
                }
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
        public IActionResult saveAfterEdit(UnitsEditDetailsModelView UnitAfterEdit)
        {
            UnitRepo unit = new UnitRepo(_context);
            if (ModelState.IsValid)
            {
                unit.EditUnits(UnitAfterEdit);


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

        public async Task<IActionResult> AgencyProfile()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var currentUser = await _userManager.GetUserAsync(User) as Users;
                // Access properties of currentUser here

                return View(currentUser);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
