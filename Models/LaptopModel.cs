using System.ComponentModel.DataAnnotations;

namespace McIntashLaptops.Models
{
    public class LaptopModel
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Processor { get; set; }
        public string Ram { get; set; }
        public string DriveSize { get; set; }
        public string graphics_card { get; set; }
        public string Weight { get; set; }
        public string OperatingSystem { get; set; }
        public LaptopModel() { }

        public LaptopModel(int id, string photo, string name, string description, decimal price, string processor, string ram, string driveSize, string graphics_card, string weight, string operatingSystem)
        {
            Id = id;
            Photo = photo;
            Name = name;
            Description = description;
            Price = price;
            Processor = processor;
            Ram = ram;
            DriveSize = driveSize;
            this.graphics_card = graphics_card;
            Weight = weight;
            OperatingSystem = operatingSystem;
        }
    }
}
