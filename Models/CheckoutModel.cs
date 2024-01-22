using Microsoft.AspNetCore.Authentication;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace McIntashLaptops.Models
{
    public class CheckoutModel
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Shipping Street")]
        public string ShippingStreet { get; set; }
        [Required]
        [DisplayName("Shipping City")]
        public string ShippingCity { get; set; }
        [Required]
        [DisplayName("Shipping State")]
        public string ShippingState { get; set; }
        [Required]
        [DisplayName("Shipping Zip")]
        public string ShippingZip { get; set; }
        [Required]
        [DisplayName("Shipping Country")]
        public string ShippingCountry { get; set; }

        public CheckoutModel()
        {
        }

        public CheckoutModel(string firstName, string lastName, string shippingStreet, string shippingCity, string shippingState, string shippingZip, string shippingCountry)
        {
            FirstName = firstName;
            LastName = lastName;
            ShippingStreet = shippingStreet;
            ShippingCity = shippingCity;
            ShippingState = shippingState;
            ShippingZip = shippingZip;
            ShippingCountry = shippingCountry;
        }
    }
}
