using Humanizer;
using McIntashLaptops.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Stripe;

namespace McIntashLaptops.Services
{
    public class CheckoutDAO : ICheckoutService
    {
        //This is used to establish a connection to a database
        string connectionString = "Data Source=tcp:johnkeen.database.windows.net,1433;Initial Catalog=McIntash;User Id=AdminGuy@johnkeen;Password=#WorkingHard2";

        ISecurity securityService;

        //This is used to inject the securityService if it is needed
        public CheckoutDAO(ISecurity securityService)
        {
            this.securityService = securityService;
        }
        //This will be used to return all orders relation records in the database
        public List<OrderModel> AllOrders()
        {
            throw new NotImplementedException();
        }

        //This will be used to return all purchase records in the database
        public List<PurchaseModel> AllPurchases()
        {
            throw new NotImplementedException();
        }

        //This is used to fulfill orders after the Stripe Payment Intent succeeds
        public void Checkout(CheckoutModel model, List<LaptopModelDTO> bought, decimal total, string email, string id, string paymentintentid)
        {
            int purchaseNumber = InsertPurchase(model,total,email,id,paymentintentid);
        
            foreach (var item in bought)
            {
                InsertOrder(purchaseNumber, item.Id, item.Quantity, "unfilled");
            }
        }
        //This will be used for deleting an order
        public bool DeleteOrder(OrderModel model)
        {
            throw new NotImplementedException();
        }

        //This will be used for finding orders with a field that matches or contains a search term
        public List<OrderModel> FindOrdersAsList(string searchTerm)
        {
            throw new NotImplementedException();
        }

        //This will be used for finding purchases with a field that matches or contains a search term
        public List<PurchaseModel> FindPurchasesAsList(string searchTerm)
        {
            throw new NotImplementedException();
        }

        //This will be used to get an order by the id
        public OrderModel GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        //This will be used to return all orders records with a partiular purchase number
        public List<OrderModel> GetOrdersByPurchaseNumber(int id)
        {
            throw new NotImplementedException();
        }

        //This will be used to get a purchase by id
        public List<PurchaseModel> GetPurchaseById(int purchaseId)
        {
            throw new NotImplementedException();
        }

        //This is used to insert an order record into the database
        public int InsertOrder(int purchaseNumber, int itemNumber, int quantity, string orderState)
        {
            int orderNumber = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO dbo.orders (PurchaseNumber, ItemNumber, Quantity, OrderState) OUTPUT INSERTED.OrderNumber VALUES (@PurchaseNumber, @ItemNumber, @Quantity, @OrderState)";

                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.Parameters.AddWithValue("@PurchaseNumber", purchaseNumber);
                myCommand.Parameters.AddWithValue("@ItemNumber",itemNumber);
                myCommand.Parameters.AddWithValue("@Quantity", quantity);
                myCommand.Parameters.AddWithValue("@OrderState", orderState);

                try
                {
                    connection.Open();
                    orderNumber = Convert.ToInt32(myCommand.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return orderNumber;
        }
        //This is used to insert a purchase into the database
        public int InsertPurchase(CheckoutModel model, decimal total, string email, string id, string paymentintentid)
        {
            int purchaseNumber = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO dbo.purchase (UserId, FirstName, LastName, Email, PaymentIntent, ShippingStreet, ShippingCity, ShippingState, ShippingZip, ShippingCountry, TotalPrice) OUTPUT INSERTED.PurchaseNumber VALUES (@UserId, @FirstName, @LastName, @Email, @PaymentIntent, @ShippingStreet, @ShippingCity, @ShippingState, @ShippingZip, @ShippingCountry, @TotalPrice)";
                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.Parameters.AddWithValue("@UserId", id);
                myCommand.Parameters.AddWithValue("@FirstName", model.FirstName);
                myCommand.Parameters.AddWithValue("@LastName", model.LastName);
                myCommand.Parameters.AddWithValue("@Email", email);
                myCommand.Parameters.AddWithValue("@PaymentIntent", paymentintentid);
                myCommand.Parameters.AddWithValue("@ShippingStreet", model.ShippingStreet);
                myCommand.Parameters.AddWithValue("@ShippingCity", model.ShippingCity);
                myCommand.Parameters.AddWithValue("@ShippingState", model.ShippingState);
                myCommand.Parameters.AddWithValue("@ShippingZip", model.ShippingZip);
                myCommand.Parameters.AddWithValue("@ShippingCountry", model.ShippingCountry);
                myCommand.Parameters.AddWithValue("@TotalPrice", total);
                try
                {
                    connection.Open();
                    purchaseNumber = Convert.ToInt32(myCommand.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return purchaseNumber;
        }

        //This will be used to update an order
        public int UpdateOrder(OrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
