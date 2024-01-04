using McIntashLaptops.Models;
using McIntashLaptops.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;
using System.Web;

namespace McIntashLaptops.Controllers
{
    [Authorize(Roles ="LaptopManager")]
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

        public bool Delete(LaptopModel laptop)
        {
            bool success = laptopDAO.Delete(laptop);
            foreach(LaptopModel found in data.PageContent)
            {
                if(found.Id==laptop.Id)
                {
                    data.PageContent.Remove(found);
                    break;
                }
            }
            return success;
        }
        public IActionResult SaveEditReturnNewCard(LaptopModel laptop)
        {
            laptopDAO.Update(laptop);
            return PartialView("_laptopCard", laptop);
        }

        public IActionResult SaveEditReturnNewRow(LaptopModel laptop)
        {
            laptopDAO.Update(laptop);
            return PartialView("_laptopRow", laptop);
        }

        public IActionResult SaveEditReturnDetails(LaptopModel laptop)
        {
            laptopDAO.Update(laptop);
            return PartialView("_details", laptop);
        }

        public IActionResult CreateLaptop(LaptopModel laptop)
        {
            int newId = laptopDAO.Insert(laptop);

            Console.WriteLine(newId);
            LaptopModel laptopModel = laptopDAO.GetLaptopById(newId);
            if (newId!=-1)
            {
                data.PageContent.Add(laptopModel);
            }
            if (HttpContext.Session.GetString("list") == "list")
            {
                return PartialView("_laptopRow", laptopModel);
            }
            else
            {
                return PartialView("_laptopCard", laptopModel);
            }
        }
    }
}
