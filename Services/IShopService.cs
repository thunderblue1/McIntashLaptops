using McIntashLaptops.Models;

namespace McIntashLaptops.Services
{
    public interface IShopService
    {
        public List<LaptopModelDTO> ShoppingCart { get; set; }

        //This holds the shopping cart items once the checkout is complete
        //It is used for order fulfillment
        public List<LaptopModelDTO> Bought { get; set; }


        //This holds a string for the Stripe checkout session
        //This way an instance of Stripe checkout session can be recreated in ThankYou action

        public string CheckoutSession { get; set; }

        //This is created for the form that asks for shipping information
        public CheckoutModel CheckoutModel { get; set; }


        //This stores the userid for purchase fulfillment
        public string CustomerId { get; set; }

        //This stores the email for purchase fulfillment
        public string Email { get; set; }


        //This adds an item to the cart using LaptopModelDTO
        public LaptopModelDTO Add(int id);

        //This is used to remove an item from the cart
        public LaptopModelDTO Remove(int id);

        //This returns the cart total
        public decimal getTotal();

        //This will set the cart total
        public void setTotal(decimal t);

        //This calculates the total of items in the cart
        public void calculateTotal();

        //This is used to fulfill orders once the checkout form is processed
        //and the payment intent was a success
        public void checkout(string paymentintentid);
       
    }
}
