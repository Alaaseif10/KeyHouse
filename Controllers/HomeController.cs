using Microsoft.AspNetCore.Mvc;

namespace KeyHouse.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
