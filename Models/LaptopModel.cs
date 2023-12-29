using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace McIntashLaptops.Models
{
    public class LaptopModel
    {
        [DisplayName("Laptop Id")]
        public int Id { get; set; }
        [DisplayName("Photo")]
        public string Photo { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [DisplayName("Processor")]
        public string Processor { get; set; }
        [DisplayName("Ram")]
        public string Ram { get; set; }
        [DisplayName("Drive Size")]
        public string DriveSize { get; set; }
        [DisplayName("Graphics Card")]
        public string GraphicsCard { get; set; }
        [DisplayName("Weight")]
        public string Weight { get; set; }
        [DisplayName("Operating System")]
        public string OperatingSystem { get; set; }
        public LaptopModel() { }

        public LaptopModel(int id, string photo, string name, string description, decimal price, string processor, string ram, string driveSize, string graphicsCard, string weight, string operatingSystem)
        {
            Id = id;
            Photo = photo;
            Name = name;
            Description = description;
            Price = price;
            Processor = processor;
            Ram = ram;
            DriveSize = driveSize;
            this.GraphicsCard = graphicsCard;
            Weight = weight;
            OperatingSystem = operatingSystem;
        }
    }
}
