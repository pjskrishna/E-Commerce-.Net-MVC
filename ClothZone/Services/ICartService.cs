using ClothZone.Models;

namespace ClothZone.Services
{
    public interface ICartService
    {
      void SaveCart (Cart category);
      List<Cart> GetCarts();
      Cart GetCart(int ID);
      void UpdateCart(Cart category);
      void DeleteCart(int ID);
      List<Cart> GetCartByUser(int ID);
        void CheckOut(Order order);
    }
}
