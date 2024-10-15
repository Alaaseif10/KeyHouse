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
        public UnitController(KeyHouseDB context, SignInManager<Users> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }


        public IActionResult Details(int id)
        {
            UnitRepo UnitRepository = new(_context);
            Units Unit = UnitRepository.GetUnitById(id);
            Boolean canInterest = false;
            if (ModelState.IsValid)
            {
                var result = _signInManager.UserManager.Users.FirstOrDefault();
                Boolean isUser = User.IsInRole("Users");

                if (User.Identity != null && User.Identity.IsAuthenticated && result != null && result.Agencies == null)
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
            return View(Unit);
        }

        public IActionResult Interest(int id)
        {
            UnitRepo unitRepo = new UnitRepo(_context);
            if (ModelState.IsValid)
            {
                var result = _signInManager.UserManager.Users.FirstOrDefault();
                unitRepo.SetInterest(id, result);
            }
            return RedirectToAction("Details", new { id });

        }

    }
}
