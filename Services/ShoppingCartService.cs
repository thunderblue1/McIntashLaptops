using McIntashLaptops.Models;
using System.Collections.Generic;
using Stripe.Checkout;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace McIntashLaptops.Services
{
    public class ShoppingCartService: IShopService
    {
        //This holds shopping cart items
        private List<LaptopModelDTO> shoppingCart = new List<LaptopModelDTO>();
        public List<LaptopModelDTO> ShoppingCart { get { return shoppingCart; } set { this.shoppingCart = value; } }

        //This holds the shopping cart items once the checkout is complete
        //It is used for order fulfillment
        private List<LaptopModelDTO> bought = new List<LaptopModelDTO>();
        public List<LaptopModelDTO> Bought { get { return bought; } set { this.bought = value; } }

        //This is the DAO for accessing laptop records
        static public ILaptopDataService laptopDAO;

        //This is the DAO for the fulfillment process
        static public ICheckoutService checkoutDAO;

        //This is the total for all items in cart
        static public decimal total;

        //This holds a string for the Stripe checkout session
        //This way an instance of Stripe checkout session can be recreated in ThankYou action

        private string checkoutSession;
        public string CheckoutSession { get { return checkoutSession; } set { checkoutSession = value; } }
        
        //This is created for the form that asks for shipping information
        private CheckoutModel checkoutModel;
        public CheckoutModel CheckoutModel { get { return checkoutModel; } set { checkoutModel = value; } }

        
        //This stores the userid for purchase fulfillment
        private string customerId;
        public string CustomerId { get { return customerId; } set { customerId = value; } }

        //This stores the email for purchase fulfillment
        private string email;
        public string Email { get { return email; } set { email = value; } }
        
        //Default Constructor
        public ShoppingCartService() {
        }

        //This adds an item to the cart using LaptopModelDTO
        public LaptopModelDTO Add(int id)
        {
            LaptopModelDTO oneItem = new LaptopModelDTO();
            oneItem.Quantity = 0;

            foreach (var item in shoppingCart)
            {
                if (item.Id == id)
                {
                    oneItem = item;
                    break;
                }
            }

            if(oneItem.Quantity>0)
            {
                oneItem.Quantity = oneItem.Quantity + 1;
            } else
            {
                LaptopModel laptop = new LaptopModel();
                laptop = laptopDAO.GetLaptopById(id);
                oneItem = new LaptopModelDTO(laptop,1);
                shoppingCart.Add(oneItem);
            }
            total += oneItem.Price;
            return oneItem;
        }

        //This is used to remove an item from the cart
        public LaptopModelDTO Remove(int id)
        {
            LaptopModelDTO oneItem = new LaptopModelDTO();
            
            foreach (var item in shoppingCart)
            {
                if(item.Id==id)
                {
                    oneItem = item;
                    break;
                }
            }
            oneItem.Quantity = oneItem.Quantity - 1;
            if (oneItem.Quantity<1) {
                shoppingCart.Remove(oneItem);
            }
            total -= oneItem.Price;
            return oneItem;
        }

        //This returns the cart total
        public decimal getTotal()
        {
            return total;
        }

        //This will set the cart total
        public void setTotal(decimal t)
        {
            total = t;
        }

        //This calculates the total of items in the cart
        public void calculateTotal()
        {
            decimal t = 0.00m;
            foreach (LaptopModelDTO laptop in ShoppingCart)
            {
                t += (laptop.Price * laptop.Quantity);
            }
            setTotal(t);
        }

        //This is used to fulfill orders once the checkout form is processed
        //and the payment intent was a success
        public void checkout(string paymentintentid)
        {
            checkoutDAO.Checkout(checkoutModel, Bought, total, email, customerId, paymentintentid);
        }
    }
}
