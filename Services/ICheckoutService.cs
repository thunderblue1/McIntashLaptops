using McIntashLaptops.Models;

namespace McIntashLaptops.Services
{
    public interface ICheckoutService
    {
        List<PurchaseModel> AllPurchases();
        List<PurchaseModel> GetPurchaseById(int purchaseId);
        List<PurchaseModel> FindPurchasesAsList(string searchTerm);
        List<OrderModel> AllOrders();
        OrderModel GetOrderById(int id);
        List<OrderModel> GetOrdersByPurchaseNumber(int id);
        List<OrderModel> FindOrdersAsList(string searchTerm);
        bool DeleteOrder(OrderModel model);
        int UpdateOrder(OrderModel model);
        void Checkout(CheckoutModel model, List<LaptopModelDTO> bought, decimal total, string email,string id, string paymentintentid);
        int InsertPurchase(CheckoutModel model, decimal total, string email, string id, string paymentintentid);

        int InsertOrder(int purchaseNumber, int itemNumber, int quantity, string orderState);
    }
}
