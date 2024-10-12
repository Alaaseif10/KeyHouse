using KeyHouse.container;
using KeyHouse.Models.Entities;
using KeyHouse.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeyHouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly KeyHouseDB _context;
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("DashBoard", "Admin");
            }
           
            else
            {
                List<Units> units = new UnitRepo(_context).GetAllUnits();

                //    List<Models.Entities.Units> units = new List<Models.Entities.Units>
                //{
                //     new Models.Entities.Units { Id = 1,
                //    Unit_Title =  Models.Enums.PropertyType.Villa,
                //    Unit_Description = "Description 1",
                //    Price = 100,
                //    Num_Bathrooms=2,
                //    Num_Rooms=3,
                //    Blocks = new Models.Entities.Blocks()
                //    {
                //        Id = 1,
                //        Block_Name= "Naser City",
                //        Cities = new Models.Entities.Cities()
                //        {
                //            Id= 1,
                //            City_Name="CAIRO",
                //            Governments = new Models.Entities.Governments()
                //            {
                //                Id = 1,
                //                Government_Name="cairo"
                //            }
                //        }
                //    },
                //    Images = new List<Models.Entities.Images>
                //    {
                //     new Images { Id = 1, Img_Path = "/img/1.jpg" },
                //     new Images { Id = 2, Img_Path = "/img/2.jpg" },
                //     new Images { Id = 3, Img_Path = "/img/3.jpg" },

                //    }
                //},
                //new Models.Entities.Units { Id = 2,
                //    Unit_Title = Models.Enums.PropertyType.Apartment,
                //    Unit_Description = "Description 2",
                //    Price = 200,
                //    Num_Bathrooms=2,
                //    Num_Rooms=3,
                //    Blocks = new Models.Entities.Blocks()
                //    {
                //        Id = 1,
                //        Block_Name= "Naser City",
                //        Cities = new Models.Entities.Cities()
                //        {
                //            Id= 1,
                //            City_Name="CAIRO",
                //            Governments = new Models.Entities.Governments()
                //            {
                //                Id = 1,
                //                Government_Name="cairo"
                //            }
                //        }
                //    },
                //    Images = new List<Models.Entities.Images>
                //    {
                //    new Images { Id = 1, Img_Path = "/img/1.jpg" },
                //    new Images { Id = 2, Img_Path = "/img/2.jpg" },
                //    new Images { Id = 3, Img_Path = "/img/3.jpg" },
                //    }
                //},
                //new Models.Entities.Units { Id = 3,
                //    Unit_Title = Models.Enums.PropertyType.Factory,
                //    Unit_Description = "Description 3",
                //    Price = 300,
                //    Num_Bathrooms=2,
                //    Num_Rooms=3,
                //    Blocks = new Models.Entities.Blocks()
                //    {
                //        Id = 1,
                //        Block_Name= "Naser City",
                //        Cities = new Models.Entities.Cities()
                //        {
                //            Id= 1,
                //            City_Name="CAIRO",
                //            Governments = new Models.Entities.Governments()
                //            {
                //                Id = 1,
                //                Government_Name="cairo"
                //            }
                //        }
                //    },
                //    Images = new List<Models.Entities.Images>
                //    {
                //    new Images { Id = 1, Img_Path = "/img/1.jpg" },
                //    new Images { Id = 2, Img_Path = "/img/2.jpg" },
                //    new Images { Id = 3, Img_Path = "/img/3.jpg" },
                //    }
                //}
                //};





                return View(units);
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
