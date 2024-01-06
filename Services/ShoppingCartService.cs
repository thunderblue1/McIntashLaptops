using McIntashLaptops.Models;

namespace McIntashLaptops.Services
{
    public class ShoppingCartService
    {

        private List<LaptopModelDTO> shoppingCart = new List<LaptopModelDTO>();
        public List<LaptopModelDTO> ShoppingCart { get { return shoppingCart; } set { this.shoppingCart = value; } }

        static public ILaptopDataService laptopDAO;

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
                oneItem =new LaptopModelDTO(laptop,1);
                shoppingCart.Add(oneItem);
            }
            return oneItem;
        }

        public LaptopModelDTO? Remove(int id)
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
            if (oneItem.Quantity>0) { 
                shoppingCart.Remove(oneItem);
            }
            if(oneItem.Quantity>0)
            {
                return oneItem;
            }
            else
            {
                return null;   
            }
        }
    }
}
