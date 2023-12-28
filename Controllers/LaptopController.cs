using McIntashLaptops.Models;
using McIntashLaptops.Services;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult SearchForm() {   
            return View(); 
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
    }
}
