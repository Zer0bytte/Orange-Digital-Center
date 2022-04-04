using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    public class CoursesControllerAPI : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
