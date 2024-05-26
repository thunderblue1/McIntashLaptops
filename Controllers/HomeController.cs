using McIntashLaptops.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace McIntashLaptops.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Constructor with dependency injection for logger
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //View shown upon arrival and logging out
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            HttpContext.Session.SetString("list", "false");
            return View();
        }

        //Shows the expectaions regarding privacy of the web application
        public IActionResult Privacy()
        {
            return View();
        }

        //Displays an error page in the event of an error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}