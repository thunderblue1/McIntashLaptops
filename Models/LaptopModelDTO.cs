using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace McIntashLaptops.Models
{
    public class LaptopModelDTO
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
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }
        public int Quantity { get; set; }

        public LaptopModelDTO() { }

        public LaptopModelDTO(LaptopModel laptop, int quantity) {
            Id = laptop.Id;
            Photo = laptop.Photo;
            Name = laptop.Name;
            Description = laptop.Description;
            Price = laptop.Price;
            Processor = laptop.Processor;
            Ram = laptop.Ram;
            DriveSize = laptop.DriveSize;
            this.GraphicsCard = laptop.GraphicsCard;
            Weight = laptop.Weight;
            OperatingSystem = laptop.OperatingSystem;
            ShortDescription = laptop.Description.Length <= 100 ? laptop.Description : laptop.Description.Substring(0, 100) + "...";
            Quantity = quantity;
        }

        public LaptopModelDTO(int id, string photo, string name, string description, decimal price, string processor, string ram, string driveSize, string graphicsCard, string weight, string operatingSystem, int quantity)
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
            ShortDescription = description.Length<=100?description:description.Substring(0,100)+"...";
            Quantity = quantity;
        }
    }
}
