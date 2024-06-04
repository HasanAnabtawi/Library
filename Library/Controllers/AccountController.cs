using Azure.Identity;
using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AccountController : Controller
    {   
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
         
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login([FromQuery] string? ReturnUrl)
        {
            if (User.Identity.IsAuthenticated) { 
                return RedirectToAction("Index", "Home"); 
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            
            
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);


                if (result.Succeeded) {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Login Attempt");
                return View(model);
            }

            return View(model);
        }


        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Name = register.Name,
                    UserName = register.Name,
                    Email = register.Email,
                    Address = register.Address,
                };

                
                
                var result = await _userManager.CreateAsync(user, register.Password!);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");

                }
                foreach(var error in result.Errors)
                {
                    
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(register);
        }

        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();

            return RedirectToAction("","Home");
        }






    }



}
