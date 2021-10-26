using hh.Models;
using hh.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var arr = _db.Categories.ToList();
            List<string> mass = new List<string>();
            for (int i = 0; i < arr.Count; i++)
                mass.Add(arr[i].Name);
            ViewBag.Categories = new SelectList(mass);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Summary Summary,IEnumerable<WorkExp> ListOfWorks, IEnumerable<Graduation> ListOfEdu, IEnumerable<Certificate> ListOfCerts)
        {
            var user = CurrentUser().Result;

            if (Summary != null )
            {
                Summary.User = user;
                Summary.UserId = user.Id;
                Summary.UpdateTime = DateTime.Now;
                if (ListOfWorks != null)
                {
                    Summary.Works = ListOfWorks.ToList();
                }
                if(ListOfEdu != null)
                {
                    Summary.Graduations = ListOfEdu.ToList();
                }
                if(ListOfCerts != null)
                {
                    Summary.Certificates = ListOfCerts.ToList();
                }
                _db.Summaries.Add(Summary);
                user.Summaries.Add(Summary);
                _db.ContextUser.Update(user);
                _db.SaveChanges();
            }
            return View();
        }
    }
}
