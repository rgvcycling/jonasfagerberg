using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using VideoOnDemand.Models;
using VideoOnDemand.Repositories;

namespace VideoOnDemand.Controllers
{
    public class HomeController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;
        public HomeController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var rep = new MockReadRepository();
            var courses = rep.GetCourses("139a4661-4e83-44b5-af73-9e0aa383875f");
            var course = rep.GetCourse("139a4661-4e83-44b5-af73-9e0aa383875f", 1);
            var video = rep.GetVideo("139a4661-4e83-44b5-af73-9e0aa383875f", 1);

            if (!_signInManager.IsSignedIn(User))
                return RedirectToAction("Login", "Account");

            return RedirectToAction("Dashboard","Membership");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        
    }
}
