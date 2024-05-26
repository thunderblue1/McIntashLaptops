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

        //This constructor is injected to ensure that we have access to laptop records
        public LaptopAPIController(ILaptopDataService dataService)
        {
            laptopDAO = dataService;
        }

        //This is used to return all laptop records when the api/ endpoint is accessed
        [HttpGet]
        public ActionResult<IEnumerable<LaptopModel>> Index()
        {
            return laptopDAO.All();
        }

        //This is used to return laptop records that match the searchTerm with /api/searchresults/searchTerm is used
        [HttpGet("searchresults/{searchTerm}")]
        public ActionResult<IEnumerable<LaptopModel>> SearchResults(string searchTerm)
        {
            return laptopDAO.SearchLaptops(searchTerm);
        }

        //This is used to return an individual laptop record when showonelaptop/{Id} is used
        [HttpGet("showonelaptop/{Id}")]
        public ActionResult<LaptopModel> ShowOneLaptop(int Id)
        {
            return laptopDAO.GetLaptopById(Id);
        }
    }
}
