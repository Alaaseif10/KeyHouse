using KeyHouse.container;
using KeyHouse.Migrations;
using KeyHouse.Models.Entities;
using KeyHouse.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Net;
using X.PagedList;

namespace KeyHouse.Controllers
{
    public class UnitController : Controller
    {
        private readonly KeyHouseDB _context;
        SignInManager<Users> _signInManager;
        UserManager<Users> _userManager;
        public UnitController(KeyHouseDB context, SignInManager<Users> signInManager, UserManager<Users> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager= userManager;

        }


        public IActionResult Details(int id)
        {
            UnitRepo UnitRepository = new(_context);
            Units Unit = UnitRepository.GetUnitById(id);
            Boolean canInterest = false;
            if (ModelState.IsValid)
            {
                var result = _signInManager.UserManager.Users.FirstOrDefault();
                if (User.Identity.IsAuthenticated && User.IsInRole("Users"))
                {
                    canInterest = true;
                }
                else
                {
                    canInterest = false;
                }
                if (canInterest)
                    canInterest = UnitRepository.IsUserInterestedBefore(result.Id, Unit.Id);
            }
            ViewBag.CanInterest = canInterest;
            return View("UnitDetails",Unit);
        }

        public async Task<IActionResult> Interest(int id)
        {
            UnitRepo unitRepo = new UnitRepo(_context);
            if (_signInManager.IsSignedIn(User))
            {
                var currentUser = await _userManager.GetUserAsync(User) as Users;
                // Access properties of currentUser here
                unitRepo.SetInterest(id, currentUser);
            }
            return RedirectToAction("Details", new { id });

        }

    }
}
