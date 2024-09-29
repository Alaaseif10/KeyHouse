using KeyHouse.ModelView;
using Microsoft.AspNetCore.Mvc;
using KeyHouse.services;

namespace KeyHouse.Controllers
{
    public class AgencyController : Controller
    {
        public IActionResult Registeration()
        {
            return View("Registration");
        }

        [HttpPost]
        public  IActionResult SaveAgencyData(AgencyUserModelView AgencyData) {
            if (ModelState.IsValid)
            {
                if (AgencyData.logo != null && AgencyData.logo.Length > 0)
                {
                    AgencyRepo agency = new AgencyRepo();
                    agency.InsertAgencyAndUser(AgencyData);
                    return View("index");
                }
            }
            return View("AgencyDashBoard");
        }


        public IActionResult Dashboard()
        {
            return View("AgencyDashBoard");
        }
    }
}
