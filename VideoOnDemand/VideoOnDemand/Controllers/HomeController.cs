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
            var courses = rep.GetCourses("649112c5-a8e9-4312-9fff-fbec8d717f99");
            var video = rep.GetVideo("649112c5-a8e9-4312-9fff-fbec8d717f99", 1);

            if (!_signInManager.IsSignedIn(User))
                return RedirectToAction("Login", "Account");
            return View();
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
