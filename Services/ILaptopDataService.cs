using McIntashLaptops.Models;

namespace McIntashLaptops.Services
{
    public interface ILaptopDataService
    {
        List<LaptopModel> All();
        List<LaptopModel> SearchLaptops(string searchTerm);
        LaptopModel GetLaptopById(int id);
        int Insert(LaptopModel laptop);
        bool Delete(LaptopModel laptop);
        int Update(LaptopModel laptop);
    }
}
