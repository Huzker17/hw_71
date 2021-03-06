using hh.Models;
using hh.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult YourProfile(string userName)
        {
            var user = _db.ContextUser.FirstOrDefault(x=>x.UserName == userName);
            var sums = _db.Summaries.Where(x => x.UserId == user.Id).ToList();
            user.Summaries = sums;
            return View(user);
        }
        public IActionResult Profile()
        {
            var user = CurrentUser().Result;
            var sums = _db.Summaries.Where(x => x.UserId == user.Id).ToList();
            user.Summaries = sums;
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Get(string Id)
        {
            EmailService emailService = new EmailService();
            var user = _db.ContextUser.FirstOrDefault(x => x.Id == Id);
            await emailService.SendEmailAsync($"{user.Email}", "Ваши данные были изменены", "Ваши данные" + $"{user.UserName}" + $"{ user.Email}" + $"{user.PhoneNumber}");
            return RedirectToAction("Profile");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            EmailService emailService = new EmailService();
            var u = CurrentUser().Result;
            u.UserName = user.UserName;
            u.Email = user.Email;
            u.PhoneNumber = user.PhoneNumber;
            await emailService.SendEmailAsync($"{user.Email}", "Ваши данные были изменены", "Ваши обновленные данные" + $"{u.UserName}" + $"{ u.Email}" + $"{u.PhoneNumber}");
            _db.ContextUser.Update(u);
            await _db.SaveChangesAsync();
            return RedirectToAction("Profile");
        }
    }
}
