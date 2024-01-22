using Humanizer;
using McIntashLaptops.Models;
using Microsoft.Data.SqlClient;
using Stripe;

namespace McIntashLaptops.Services
{
    public class CheckoutDAO : ICheckoutService
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=McIntash;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        ISecurity securityService;
        public CheckoutDAO(ISecurity securityService)
        {
            this.securityService = securityService;
        }

        public List<OrderModel> AllOrders()
        {
            throw new NotImplementedException();
        }

        public List<PurchaseModel> AllPurchases()
        {
            throw new NotImplementedException();
        }

        public void Checkout(CheckoutModel model, List<LaptopModelDTO> bought, decimal total, string email, string id, string paymentintentid)
        {
            int purchaseNumber = InsertPurchase(model,total,email,id,paymentintentid);
        
            foreach (var item in bought)
            {
                InsertOrder(purchaseNumber, item.Id, item.Quantity, "unfilled");
            }
        }

        public bool DeleteOrder(OrderModel model)
        {
            throw new NotImplementedException();
        }

        public List<OrderModel> FindOrdersAsList(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public List<PurchaseModel> FindPurchasesAsList(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public OrderModel GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderModel> GetOrdersByPurchaseNumber(int id)
        {
            throw new NotImplementedException();
        }

        public List<PurchaseModel> GetPurchaseById(int purchaseId)
        {
            throw new NotImplementedException();
        }

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

        public List<OrderModel> SearchOrders(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int UpdateOrder(OrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
