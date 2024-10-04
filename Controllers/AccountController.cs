using KeyHouse.Models.Entities;
using KeyHouse.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace KeyHouse.Controllers
{
    public class AccountController : Controller
    {

        UserManager<Users> _userManager;
        SignInManager<Users> _signInManager;
        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel newUser)
        {
                Users user = new Users();
                user.UserName = newUser.UserName;
                user.Email = newUser.Email;
                user.PhoneNumber = newUser.UserPhone;
                user.Creation_date = DateTime.Now;
                user.status = 1; // Active status
                user.User_Type = 1; // Client type // Register as a regular user

                IdentityResult result = await _userManager.CreateAsync(user, newUser.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }


            return View("Register", newUser);
        }
        [HttpGet]
        public IActionResult RegisterAgency()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAgency(RegisterAgencyViewModel newUser)
        {
            
                    Agencies user = new Agencies();
                    user.UserName = newUser.UserName;
                    user.Email = newUser.Email;
                    user.PhoneNumber = newUser.UserPhone;
                    user.Creation_date = DateTime.Now;
                    user.status = 1; // Active status
                    user.User_Type = 2; // Agency type // Register as a Agency Responsible
                    user.AgencyName = newUser.AgencyName;
                    user.AgencyDescription = newUser.AgencyDescription;
                    user.NumCompany = newUser.NumCompany;
                    // user.logo = newUser.logo;
                    IdentityResult result = await _userManager.CreateAsync(user, newUser.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }

                    }

           return View("Register", newUser);

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel LoginUser)
        {

            if (ModelState.IsValid)
            {
                Users user = await _userManager.FindByEmailAsync(LoginUser.Email);
                if (user != null)
                {
                    SignInResult result = await _signInManager.PasswordSignInAsync(user, LoginUser.Password, false, false);
                    if (result.Succeeded)
                    {
                        //Create Cookie
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password is Invalid");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is Invalid");
                }

            }
            return View();
        }
        public IActionResult RegisterAs()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
