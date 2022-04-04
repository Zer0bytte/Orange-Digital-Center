using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ODC_Courses.Models;
using System.Diagnostics;
using System.Linq;

namespace ODC_Courses.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult IndexAsync()
        {

            //ODCCoursesManagmentContext db = new ODCCoursesManagmentContext();
            //var DDD = db.TbStudents.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
