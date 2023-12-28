using McIntashLaptops.Models;
using NuGet.Packaging.Licenses;

namespace McIntashLaptops.Services
{
    public class DataService
    {
        private List<LaptopModel> pageContent = new List<LaptopModel>();
        public List<LaptopModel> PageContent { get { return pageContent; } set { this.pageContent = value; } }

        public DataService() { }
    }
}
