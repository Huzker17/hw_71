using hh.Models;
using hh.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hh.Controllers
{
    public class SummaryController : Controller
    {
        private readonly UserManager<User> _userManager;
        private ApplicationDbContext _db;

        public SummaryController(UserManager<User> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        private async Task<User> CurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Summary s)
        {
            var user = CurrentUser().Result;

            if (s.Name != null )
            {
                if (s != null)
                {
                    s.UpdateTime = DateTime.Now;
                    user.Summaries.Add(s);
                }
            }
            return View();
        }
        //public  JsonResult Add(WorkExp work)
        //{
        //    var result = _db.Works.Add(work);
        //    _db.SaveChangesAsync();
        //    Console.WriteLine("work is saved");
        //    return Json(new { work });
        //}
        [HttpPost]
        public IActionResult Add(string name, DateTime startDate, DateTime endDate, string spec, string text)
        {
            var x = name;
            return Ok();
        }
    }
}
