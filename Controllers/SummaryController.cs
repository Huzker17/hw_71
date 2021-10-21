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
            var sumvm = new SummaryViewModel();
            return View(sumvm);
        }

        [HttpPost]
        public IActionResult Create(SummaryViewModel s)
        {
            var user = CurrentUser().Result;
            if(s.Work != null)
            {
                _db.Works.Add(s.Work);
            }
            if (s.Summary.Name != null )
            {
                if (s.Summary != null)
                {
                    s.Summary.UpdateTime = DateTime.Now;
                    s.Work.SummaryId = s.Summary.Id;
                    s.Summary.Works.Add(s.Work);
                    user.Summaries.Add(s.Summary);
                }
            }
            return View();
        }
        [HttpPost]
        //public  JsonResult Add(WorkExp work)
        //{
        //    var result = _db.Works.Add(work);
        //    _db.SaveChangesAsync();
        //    Console.WriteLine("work is saved");
        //    return Json(new { work });
        //}
        public IActionResult Add()
        {
            return Ok();
        }
    }
}
