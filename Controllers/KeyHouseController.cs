using Microsoft.AspNetCore.Mvc;

namespace KeyHouse.Controllers
{
    public class KeyHouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
