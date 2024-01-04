using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using McIntashLaptops.Services;
using McIntashLaptops.Models;
using System.Numerics;

namespace McIntashLaptops.Controllers
{

    public class RegisterController : Controller
    {
        SecurityService securityService;

        public RegisterController(SecurityService secuityService)
        {
            this.securityService = secuityService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SubmitForm(UserModel user)
        {
            if (securityService.AlreadyExists(user))
            {
                ViewBag.playerExists = true;
                return View("Index");
            }
            else
            {
                bool registrationSuccess = securityService.AddUser(user);
                ViewBag.registered = registrationSuccess;
                if (registrationSuccess)
                {
                    return View("~/Views/Login/Index.cshtml");
                }
                else
                {
                    return View("Index");
                }

            }
        }
    }
}
