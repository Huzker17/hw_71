using hh.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hh.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private ApplicationDbContext _db;

        public UserController(UserManager<User> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        private async Task<User> CurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
        public IActionResult Profile()
        {
            var user = CurrentUser().Result;
            return View(user);
        }
    }
}
