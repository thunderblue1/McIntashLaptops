using McIntashLaptops.Models;
using System.Collections.Generic;
using Stripe.Checkout;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace McIntashLaptops.Services
{
    public class ShoppingCartService
    {

        private List<LaptopModelDTO> shoppingCart = new List<LaptopModelDTO>();
        public List<LaptopModelDTO> ShoppingCart { get { return shoppingCart; } set { this.shoppingCart = value; } }

        private List<LaptopModelDTO> bought = new List<LaptopModelDTO>();
        public List<LaptopModelDTO> Bought { get { return bought; } set { this.bought = value; } }

        static public ILaptopDataService laptopDAO;

        static public ICheckoutService checkoutDAO;

        static public decimal total;

        private string lastReciept;
        public string LastReciept { get { return lastReciept; } set { lastReciept = value; }  }

        private string checkoutSession;
        public string CheckoutSession { get { return checkoutSession; } set { checkoutSession = value; } }
        private CheckoutModel checkoutModel;
        public CheckoutModel CheckoutModel { get { return checkoutModel; } set { checkoutModel = value; } }

        private string customerId;

        public string CustomerId { get { return customerId; } set { customerId = value; } }
        private string email;
        public string Email { get { return email; } set { email = value; } }
        public ShoppingCartService() {
        }

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

        public decimal getTotal()
        {
            return total;
        }

        public void setTotal(decimal t)
        {
            total = t;
        }
        public void calculateTotal()
        {
            decimal t = 0.00m;
            foreach (LaptopModelDTO laptop in ShoppingCart)
            {
                t += (laptop.Price * laptop.Quantity);
            }
            setTotal(t);
        }
        public void checkout(string paymentintentid)
        {
            checkoutDAO.Checkout(checkoutModel, Bought, total, email, customerId, paymentintentid);
        }
    }
}
