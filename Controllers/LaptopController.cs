using McIntashLaptops.Models;
using McIntashLaptops.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;
using System.Web;

namespace McIntashLaptops.Controllers
{
    public class LaptopController : Controller
    {
        ILaptopDataService laptopDAO;
        static DataService data = new DataService();
        public LaptopController(ILaptopDataService dataService)
        {
            laptopDAO = dataService;
        }

        public IActionResult Index()
        {
            data.PageContent = laptopDAO.All();
            return View("Index");
        }
        public IActionResult SearchResults(string searchTerm)
        {
            data.PageContent = laptopDAO.SearchLaptops(searchTerm);
            return View("Index");
        }
        public IActionResult Toggle()
        {
            if(HttpContext.Session.GetString("list")=="true")
            {
                HttpContext.Session.SetString("list", "false");
            } else if (HttpContext.Session.GetString("list") == "false")
            {
                HttpContext.Session.SetString("list", "true");
            }
            if(HttpContext.Session.GetString("list") == "true")
            {
                return PartialView("_List",data.PageContent);
            } else
            {
                return PartialView("_Display",data.PageContent);
            }

        }
        public IActionResult getResults()
        {
            if (HttpContext.Session.GetString("list") == "true")
            {
                return PartialView("_List", data.PageContent);
            }
            else
            {
                return PartialView("_Display", data.PageContent);
            }
        }
        public IActionResult ShowOneLaptop(int Id)
        {
            return View(laptopDAO.GetLaptopById(Id));
        }

        public JsonResult ShowOneLaptopJSON(int Id)
        {
            return Json(laptopDAO.GetLaptopById(Id));
        }

        public ActionResult Delete(LaptopModel laptop)
        {
            bool success = laptopDAO.Delete(laptop);
            if (success)
            {
                return View("Index");
            }
            else
            {
                ErrorViewModel m = new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                return View("Error", m);
            }
        }
        public IActionResult SaveEditReturnNewCard (LaptopModel laptop)
        {
            laptopDAO.Update(laptop);
            return PartialView("_laptopCard", laptop);
        }

        public IActionResult SaveEditReturnNewRow(LaptopModel laptop)
        {
            laptopDAO.Update(laptop);
            return PartialView("_laptopRow", laptop);
        }

    }
}
