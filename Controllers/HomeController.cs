using KeyHouse.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyHouse.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           // Locations locations = new Locations();
            //locations.Insertion();
            return View();
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
