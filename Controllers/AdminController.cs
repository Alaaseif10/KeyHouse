using KeyHouse.container;
using KeyHouse.Models.Entities;
using KeyHouse.ModelView;
using KeyHouse.services;
using KeyHouse.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KeyHouse.Controllers
{
    public class AdminController : Controller
    {

        private readonly KeyHouseDB _context;
        public AdminController(KeyHouseDB context)
        {
            _context = context;
        }
        public IActionResult DashBoard()
        {
            return View();
        }

        public IActionResult Agencies(int? page)
        {
            AgencyRepo AgencyRepository = new AgencyRepo(_context);
            List<Agencies> Agencies = AgencyRepository.GetAllAgencies();
            // Set the page number (default is 1) and page size
            int pageNumber = page ?? 1;
            int pageSize = 8;

            // Use X.PagedList to paginate the data
            var pagedData = Agencies.ToPagedList(pageNumber, pageSize);
            return View(pagedData);
        }

        public IActionResult Properties(int? page)
        {
            UnitRepo unitRepo = new UnitRepo();
            //List<Units> Units = unitRepo.GetAllUnits();
            // Set the page number (default is 1) and page size
            int pageNumber = page ?? 1;
            int pageSize = 8;

            // Use X.PagedList to paginate the data
            //var pagedData = Units.ToPagedList(pageNumber, pageSize);
            //pagedData
            return View();
            
        }
        public IActionResult Users(int? page)
        {
            UserRepository userRepository = new UserRepository(_context);
            List<Users> users= userRepository.GetAllUsers();

            List<UserAgencyViewModel> mappedRes = new List<UserAgencyViewModel>();
           
            // Set the page number (default is 1) and page size
            int pageNumber = page ?? 1;
            int pageSize = 8;

            // Use X.PagedList to paginate the data
            var pagedData = users.ToPagedList(pageNumber, pageSize);
            return View(pagedData);
        }
        
    }
}
