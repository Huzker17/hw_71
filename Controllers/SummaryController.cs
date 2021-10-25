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
        public IActionResult Create(Summary Summary,IEnumerable<WorkExp> ListOfWorks)
        {
            var user = CurrentUser().Result;

            if (ListOfWorks != null )
            {
                if (ListOfWorks != null)
                {
                    //ListOfWorks.Summary.UpdateTime = DateTime.Now;
                    //user.Summaries.Add(ListOfWorks.Summary);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(IEnumerable<Summary> s)
        {
            return Ok();
        }
    }
}
