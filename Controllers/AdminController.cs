using KeyHouse.container;
using KeyHouse.Models.Entities;
using KeyHouse.ModelView;
using KeyHouse.services;
using KeyHouse.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics.Contracts;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KeyHouse.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {

        private readonly KeyHouseDB _context;
        public AdminController(KeyHouseDB context)
        {
            _context = context;
        }
        public IActionResult DashBoard(int? page)
        {
            AgencyRepo AgencyRepository = new AgencyRepo(_context);
            List<Agencies> Agencies = AgencyRepository.GetAllAgencies();

            UnitRepo unitRepo = new UnitRepo(_context);
            List<Units> Units = unitRepo.GetAllUnits();

            UserRepository userRepository = new UserRepository(_context);
            List<Users> users = userRepository.GetAllUsers();

            ViewBag.Users = users.Count;
            ViewBag.Agency = Agencies.Count;
            ViewBag.Properites = Units.Count;
            List<Agencies> addedAgenciesToday = AgencyRepository.GetAddedAgencyByToday();
            int pageNumber = page ?? 1;
            int pageSize = 8;

            // Use X.PagedList to paginate the data
            var pagedData = addedAgenciesToday.ToPagedList(pageNumber, pageSize);
            return View(pagedData);
        }
        public IActionResult GetAgenciesDetails(string id)
        {
            AgencyRepo AgencyRepository = new AgencyRepo(_context);
            Agencies Agencies = AgencyRepository.GetAgencyById(id);
            return View(Agencies);
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
            UnitRepo unitRepo = new UnitRepo(_context);
            List<Units> Units = unitRepo.GetAllUnits();
            int pageNumber = page ?? 1;
            int pageSize = 8;

            // Use X.PagedList to paginate the data
            var pagedData = Units.ToPagedList(pageNumber, pageSize);
            
            return View(pagedData);

        }
        public IActionResult Users(int? page)
        {
            UserRepository userRepository = new UserRepository(_context);
            List<Users> users = userRepository.GetAllUsers();

            List<UserAgencyViewModel> mappedRes = new List<UserAgencyViewModel>();
            foreach (var user in users)
            {
                if (user is Admin admin)
                    continue;
                var newuser = new UserAgencyViewModel()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Creation_date = user.Creation_date,
                    status = user.status,
                    AgencyName = user is Agencies agencies == true ? agencies.AgencyName:null
                };
                mappedRes.Add(newuser);
            }
            // Set the page number (default is 1) and page size
            int pageNumber = page ?? 1;
            int pageSize = 8;

            // Use X.PagedList to paginate the data
            var pagedData = mappedRes.ToPagedList(pageNumber, pageSize);
            return View(pagedData);
        }

        public IActionResult AddContract(string AgencyID)
        {
            ContractRepo contractRepo = new ContractRepo(_context);

            Contracts contractres = contractRepo.getContractByAgencyID(AgencyID);
            if (contractres != null)
            {
                TempData["Messag"] = "You can't create contract while there is one Active";
                return RedirectToAction("GetAgenciesDetails", "Admin", new { id = AgencyID });

            }
            ViewBag.AgencyId = AgencyID;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveContract(AgencyContractViewModel contract)
        {
            if (ModelState.IsValid)
            {
                ContractRepo contractRepo = new ContractRepo(_context);

              
                AgencyRepo AgencyRepository = new AgencyRepo(_context);
                Agencies Agencies = AgencyRepository.GetAgencyById(contract.AgencyID);
                Contracts newContract = new Contracts();
                newContract.Contract_Name = contract.Contract_Name;
                newContract.Start_date = contract.Start_date;
                newContract.End_date= contract.End_date;
                newContract.Agencies = Agencies;
                int res = contractRepo.createContact(newContract);
                if (res != 0)
                {
                    return RedirectToAction("GetAgenciesDetails","Admin", new { id = contract.AgencyID });

                }

            }
            return View("AddContract");
        }

        public IActionResult ApproveAgency(string AgencyID)
        {
            AgencyRepo AgencyRepository = new AgencyRepo(_context);
            AgencyRepository.EditAgencyStatus(AgencyID,3);
            return RedirectToAction("GetAgenciesDetails", "Admin", new { id = AgencyID });
        }
        public IActionResult RejectAgency(string AgencyID)
        {
            AgencyRepo AgencyRepository = new AgencyRepo(_context);
            AgencyRepository.EditAgencyStatus(AgencyID,2);
            return RedirectToAction("GetAgenciesDetails", "Admin", new { id = AgencyID });
        }

        public IActionResult Profile()
        {
            UserRepository userRepository = new UserRepository(_context);
            Admin Admin = userRepository.GetAdmin();
            return View(Admin);
        }
    }
}
