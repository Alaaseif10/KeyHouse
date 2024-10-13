using KeyHouse.Models.Entities;
using KeyHouse.ModelView;
using Microsoft.AspNetCore.Authorization;
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
                             //TO-DO
                             //user.User_Type = 1; // Client type // Register as a regular user

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

            var fileName = newUser.logo.FileName;
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/logo", fileName);
            //// Save the file to the path
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                newUser.logo.CopyToAsync(stream);
            }

            Agencies user = new Agencies();
            user.UserName = newUser.UserName;
            user.Email = newUser.Email;
            user.PhoneNumber = newUser.UserPhone;
            user.Creation_date = DateTime.Now;
            user.status = 1; // Active status
            //TO-DO
            //user.User_Type = 2; // Agency type // Register as a Agency Responsible
            user.AgencyName = newUser.AgencyName;
            user.AgencyDescription = newUser.AgencyDescription;
            user.NumCompany = newUser.NumCompany;
            user.AgencyStatus = 1;
            user.logo = $"/logo/{fileName}";
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

            return View("RegisterAgency", newUser);

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
                // Find user by email
                Users user = await _userManager.FindByEmailAsync(LoginUser.Email);

                // Check if user exists
                if (user != null)
                {
                    // Check if user is of type Agencies
                    if (user is Agencies agency)
                    {
                        if (agency.AgencyStatus == 1)
                        {
                            ModelState.AddModelError("", "Your Account is pending, Admin is confirming your data.");
                        }
                        else if (agency.AgencyStatus == 2)
                        {
                            ModelState.AddModelError("", "Sorry, your Account has been rejected.");
                        }
                        else
                        {
                            // Try to sign in the user
                            SignInResult result = await _signInManager.PasswordSignInAsync(user, LoginUser.Password, false, false);
                            if (result.Succeeded)
                            {
                                if (user is Agencies) 
                                {
                                    //Assign Role in Agencies
                                    await _userManager.AddToRoleAsync(user, "Agencies");
                                }

                                    // Create Cookie and sign in
                                    await _signInManager.SignInAsync(user, isPersistent: false);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Password is Invalid");
                            }
                        }
                    }
                    else
                    {
                        // If user is not an agency, continue with normal login
                        SignInResult result = await _signInManager.PasswordSignInAsync(user, LoginUser.Password, false, false);
                        if (result.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            if (user is Admin admin)
                                
                                return RedirectToAction("DashBoard", "Admin");
                            else
                                return RedirectToAction("Index", "Home");

                        }
                        else
                        {
                            ModelState.AddModelError("", "Password is Invalid");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is Invalid");
                }
            }

            return View(LoginUser);
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
