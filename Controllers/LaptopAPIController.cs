using McIntashLaptops.Models;
using McIntashLaptops.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;
using System.Web;

namespace McIntashLaptops.Controllers
{
    [ApiController]
    [Route("api/")]
    public class LaptopAPIController : ControllerBase
    {
        ILaptopDataService laptopDAO;

        public LaptopAPIController(ILaptopDataService dataService)
        {
            laptopDAO = dataService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<LaptopModel>> Index()
        {
            return laptopDAO.All();
        }
        [HttpGet("searchresults/{searchTerm}")]
        public ActionResult<IEnumerable<LaptopModel>> SearchResults(string searchTerm)
        {
            return laptopDAO.SearchLaptops(searchTerm);
        }
        [HttpGet("showonelaptop/{Id}")]
        public ActionResult<LaptopModel> ShowOneLaptop(int Id)
        {
            return laptopDAO.GetLaptopById(Id);
        }
    }
}
