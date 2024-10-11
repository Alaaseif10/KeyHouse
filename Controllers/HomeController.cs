using KeyHouse.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyHouse.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("DashBoard", "Admin");
            }
            // Locations locations = new Locations();
            //locations.Insertion();
            else
            {
                return View();
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
