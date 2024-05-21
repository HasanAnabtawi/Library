using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class UsersController:Controller
    {


        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }


        public IActionResult Index()
        {
            var data=_userManager.Users;
            return View(data);
        }

    }
}
