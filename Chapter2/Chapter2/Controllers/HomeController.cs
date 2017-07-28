using Chapter2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter2.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var model = new Video { Id = 1, Title = "Shreck" };

            return View(model);
        }
    }
}
