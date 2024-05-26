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

        //Constructor with injection for dataservice for storing search results
        public LaptopController(ILaptopDataService dataService)
        {
            laptopDAO = dataService;
        }

        //This returns the page responsible for CRUD operations
        public IActionResult Index()
        {
            data.PageContent = laptopDAO.All();
            return View("Index");
        }

        //This is used to perform a search and return the results
        public IActionResult SearchResults(string searchTerm)
        {
            data.PageContent = laptopDAO.SearchLaptops(searchTerm);
            return View("Index");
        }

        //This will switch between a table of products and a grid of cards
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
        //This sets up either the grid of cards or table of laptop records upon load
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

        //This will return a page that shows a laptop with a specified id
        public IActionResult ShowOneLaptop(int Id)
        {
            return View(laptopDAO.GetLaptopById(Id));
        }

        //This returns a Json object containing a laptop record
        //It is used in site.js
        public JsonResult ShowOneLaptopJSON(int Id)
        {
            return Json(laptopDAO.GetLaptopById(Id));
        }

        //This is used to delete a laptop record
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

        //This is used to save data from an edit form and update the view with a card
        public IActionResult SaveEditReturnNewCard(LaptopModel laptop)
        {
            laptopDAO.Update(laptop);
            laptop.ShortDescription = laptop.Description.Length <= 100 ? laptop.Description : laptop.Description.Substring(0, 100) + "...";
            return PartialView("_laptopCard", laptop);
        }

        //This is used to save data from an edit form and update the view with a table row
        public IActionResult SaveEditReturnNewRow(LaptopModel laptop)
        {
            laptopDAO.Update(laptop);
            laptop.ShortDescription = laptop.Description.Length<=100?laptop.Description:laptop.Description.Substring(0, 100)+"...";
            return PartialView("_laptopRow", laptop);
        }

        //This is used to save data from an edit form and update the view with a _details partial view
        public IActionResult SaveEditReturnDetails(LaptopModel laptop)
        {
            laptopDAO.Update(laptop);
            return PartialView("_details", laptop);
        }

        //This is used by the create form for creating a laptop record
        public IActionResult CreateLaptop(LaptopModel laptop)
        {
            int newId = laptopDAO.Insert(laptop);

            LaptopModel laptopModel = laptopDAO.GetLaptopById(newId);
            if (newId!=-1)
            {
                data.PageContent.Add(laptopModel);
            }
            if (HttpContext.Session.GetString("list") == "true")
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
