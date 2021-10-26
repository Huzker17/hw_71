using hh.Interfaces;
using hh.Models;
using hh.ViewModels;
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
        private readonly ICommentService service;

        public EmployeeController(UserManager<User> userManager, ApplicationDbContext db, ICommentService service)
        {
            _userManager = userManager;
            _db = db;
            this.service = service;

        }
        public IActionResult Index()
        {
            if (CurrentUser().Result != null)
            {
                var sums = _db.Summaries.Where(x => x.UserId == CurrentUser().Result.Id).ToList();
                CurrentUser().Result.Summaries = sums;
                if (CurrentUser().Result.Summaries.Count > 0)
                {
                    var vacs = _db.Vacancies.Include(v => v.Comp).OrderByDescending(x => x.UpdateTime).Where(x => x.Vision != false).ToList();
                    return View(vacs);
                }
                else
                {
                    return RedirectToAction("Create", "Summary");
                }
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
        }
        public JsonResult AllComments(int curPage, int itemsPerPage)
        {
            return Json(new { CommentPageViewModel = service.GetCommentsForPage(curPage, itemsPerPage) });
        }

        private async Task<User> CurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
        public IActionResult CompProfile(string Id)
        {
            var comp = _db.ContextUser.FirstOrDefault(c => c.Id == Id);
            return View(comp);
        }
        [HttpPost]
        public IActionResult FeedBack(int Id)
        {
            var fb = new Feedback();
            fb.User = CurrentUser().Result;
            fb.UserId = CurrentUser().Result.Id;
            var Vacancy = _db.Vacancies.FirstOrDefault(x => x.Id == Id);
            fb.Vacancy = Vacancy;
            fb.VacancyId = Id;
            _db.Feedbacks.Add(fb);
            _db.SaveChanges();
            var messages = _db.Messages.Include(x => x.User).Include(x => x.Comp).Where(x => x.User == CurrentUser().Result &&
                                              x.Comp == Vacancy.Comp).ToList();
            MessageViewModel mess = new MessageViewModel
            {
                Messages = messages,
                Vac = Vacancy
            };
            return View(mess);
        }
        [HttpPost]

        public async Task<JsonResult> Add(string commentText, string Id)
        {
            User user = CurrentUser().Result;
            var comp = _db.ContextUser.FirstOrDefault(s => s.Id == Id);
            Message message = new Message
            {
                User = user,
                Comp = comp,
                Text = commentText,
                SentTime = DateTime.Now,
            };
            var result = _db.Messages.AddAsync(message);
            if (result.IsCompleted)
            {

                await _db.SaveChangesAsync();
            }
            string Photo = user.Photo;
            string UserName = user.UserName;
            string SentTime = DateTime.Now.ToString();
            string[] mes =
            {
                Photo,
                UserName,
                commentText,
                SentTime
            };
            return Json(mes);
        }

        public IActionResult Profile()
        {
            var ser = CurrentUser().Result;
            var user = _db.Users.Include(u => u.Vacancies).FirstOrDefault(u => u.Id == ser.Id);
            return View(user);
        }
        public IActionResult Create()
        {
            var arr = _db.Categories.ToList();
            List<string> mass = new List<string>();
            for (int i = 0; i < arr.Count; i++)
                mass.Add(arr[i].Name);
            ViewBag.Categories = new SelectList(mass);
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
            var arr = _db.Categories.ToList();
            List<string> mass = new List<string>();
            for (int i = 0; i < arr.Count; i++)
                mass.Add(arr[i].Name);
            ViewBag.Categories = new SelectList(mass);
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
                vacancy.CompId = comp.Id;
                vacancy.Comp = comp;
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
