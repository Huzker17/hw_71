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
            if (s != null )
            {
                if (s.Summary != null)
                {
                    s.Summary.Works.Add(s.Work);
                    user.Summaries.Add(s.Summary);
                }
            }
            return View();
        }
    }
}
