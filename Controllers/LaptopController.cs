using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace McIntashLaptops.Controllers
{
    public class LaptopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string Message(string name, int secretNumber=13)
        {
            return HttpUtility.HtmlEncode("Hello "+name+" the secret number is "+secretNumber);
        }
        public IActionResult Welcome()
        {
            return View();
        }
    }
}
