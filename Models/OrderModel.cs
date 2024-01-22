namespace McIntashLaptops.Models
{
    public class OrderModel
    {

        public int OrderNumber { get; set; }
        public int PurchaseNumber { get; set; }
        public int ItemNumber { get; set; }
        public int Quantity { get; set; }
        public string OrderState { get; set; }
        public OrderModel()
        {
        }

        public OrderModel(int orderNumber, int purchaseNumber, int itemNumber, int quantity, string orderState)
        {
            OrderNumber = orderNumber;
            PurchaseNumber = purchaseNumber;
            ItemNumber = itemNumber;
            Quantity = quantity;
            OrderState = orderState;
        }
    }
}
