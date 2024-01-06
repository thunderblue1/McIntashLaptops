using McIntashLaptops.Models;
using McIntashLaptops.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace McIntashLaptops.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        ILaptopDataService laptopDAO;
        static ShoppingCartService shoppingCartService = new ShoppingCartService();

        public ShopController(ILaptopDataService dataService)
        {
            laptopDAO = dataService;
        }

        public IActionResult Index()
        {
            return View("Index",laptopDAO.All());
        }
        public IActionResult SearchResults(string searchTerm)
        {
            return View("Index",laptopDAO.SearchLaptops(searchTerm));
        }

        public IActionResult Cart()
        {
            return View("Cart", shoppingCartService.ShoppingCart);
        }

        public string AddToCart(int id)
        {
            LaptopModelDTO oneItem =  shoppingCartService.Add(id);
            return oneItem.ToString();
        }

        public IActionResult AddOneToCart(int id)
        {
            LaptopModelDTO oneItem = shoppingCartService.Add(id);
            return PartialView("_laptopRowDTO", oneItem);
        }

        public IActionResult? RemoveFromCart(int id)
        {

            return null;
        }
    }
}
