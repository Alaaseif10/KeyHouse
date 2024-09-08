using Microsoft.AspNetCore.Mvc;

namespace KeyHouse.Controllers
{
    public class KeyHouseDB : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
