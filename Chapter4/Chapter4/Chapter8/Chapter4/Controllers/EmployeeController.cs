using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        public ContentResult Name()
        {
            return Content("Ray Garza");
        }

        public string Country()
        {
            return "USA";
        }

        public string Index()
        {
            return "Hi Aby! I'm now in the Employee Controller.";
        }
    }
}
