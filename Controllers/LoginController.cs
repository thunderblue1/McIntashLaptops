using McIntashLaptops.Models;
using McIntashLaptops.Services;
using Microsoft.AspNetCore.Mvc;

namespace McIntashLaptops.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityService securityService = new SecurityService();

            if(securityService.IsValid(user))
            {
                HttpContext.Session.SetString("list", "true");
                return View("LoginSuccess",securityService.GetUser(user));
            } else
            {
                return View("LoginFailure",user);
            }
        }
    }
}
