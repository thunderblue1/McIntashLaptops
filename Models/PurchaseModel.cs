namespace McIntashLaptops.Models
{
    public class PurchaseModel
    {
        public int PurchaseNumber { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditCard { get; set; }

        public string ShippingStreet { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingZip { get; set; }
        public string ShippingCountry { get; set; }

        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public PurchaseModel()
        {
        }

        public PurchaseModel(int purchaseNumber, string userId, string firstName, string lastName, string creditCard, string shippingStreet, string shippingCity, string shippingState, string shippingZip, string shippingCountry, decimal totalPrice, DateTime purchaseDate)
        {
            PurchaseNumber = purchaseNumber;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            CreditCard = creditCard;
            ShippingStreet = shippingStreet;
            ShippingCity = shippingCity;
            ShippingState = shippingState;
            ShippingZip = shippingZip;
            ShippingCountry = shippingCountry;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
        }
    }
}
