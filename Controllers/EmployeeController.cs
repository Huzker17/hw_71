using hh.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hh.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private ApplicationDbContext _db;

        public EmployeeController(UserManager<User> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            if (CurrentUser().Result.Summaries != null)
            {
                var vacs = _db.Vacancies.OrderByDescending(x => x.UpdateTime).Where(x => x.Vision != false).ToList();
                return View(vacs);
            }
            else
            {
                return RedirectToAction("Create","Summary");
            }
        }

        private async Task<User> CurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        public IActionResult Profile()
        {
            var ser = CurrentUser().Result;
            var user = _db.Users.Include(u => u.Vacancies).FirstOrDefault(u => u.Id == ser.Id);
            return View(user);
        }
        public IActionResult Create()
        {
            ArrayList categories = new ArrayList
            {
                        "Информационные технологии" ,
                        "Бизнес дело" ,
                         "Финансы" ,
                        "Банк" ,
                        "Инженерия" 
            };
            ViewBag.Categories = new SelectList(categories);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            var u = CurrentUser().Result;
            u.UserName = user.UserName;
            u.Email = user.Email;
            u.PhoneNumber = user.PhoneNumber;
            _db.ContextUser.Update(u);
            await _db.SaveChangesAsync();
            return RedirectToAction("Profile");
        }
        public IActionResult EditVacancy(int Id)
        {
            ArrayList categories = new ArrayList
            {
                        "Информационные технологии" ,
                        "Бизнес дело" ,
                         "Финансы" ,
                        "Банк" ,
                        "Инженерия"
            };
            ViewBag.Categories = new SelectList(categories);
            var vac = _db.Vacancies.FirstOrDefault(v => v.Id == Id);
            return View(vac);
        }
        public IActionResult Refresh(int Id)
        {
            var vac = _db.Vacancies.FirstOrDefault(v => v.Id == Id);
            vac.UpdateTime = DateTime.Now;
            _db.Vacancies.Update(vac);
            _db.SaveChanges();
            return RedirectToAction("Profile");
        }
        [HttpPost]
        public IActionResult EditVacancy(Vacancy vac)
        {

            if(vac != null)
            {
                vac.UpdateTime = DateTime.Now;
                _db.Vacancies.Update(vac);
                _db.SaveChanges();
                return RedirectToAction("Profile");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Create(Vacancy vacancy)
        {
            if (vacancy != null)
            {
                var comp = CurrentUser().Result;
                vacancy.UpdateTime = DateTime.Now;
                _db.Vacancies.Add(vacancy);
                comp.Vacancies.Add(vacancy);
                _db.ContextUser.Update(comp);
                _db.SaveChanges();
                return RedirectToAction("Profile");
            }
            else
            {
                return View();
            }
        }
    }
}
