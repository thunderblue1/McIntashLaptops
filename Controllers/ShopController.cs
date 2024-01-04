using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace McIntashLaptops.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
