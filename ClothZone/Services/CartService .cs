using ClothZone.Models;

namespace ClothZone.Services
{
    public class CartService : ICartService
    {
        private readonly ECContext context;

        public CartService(ECContext context)
        {
            this.context = context;
        }

        void ICartService.SaveCart(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }

        List<Cart> ICartService.GetCarts()
        {
            return context.Carts.ToList();
        }

        Cart ICartService.GetCart(int ID)
        {
            return context.Carts.Find(ID);
        }
        List<Cart> ICartService.GetCartByUser(int ID)
        {
           List<Cart> carts = new List<Cart>();
            carts = context.Carts.Where(e => e.UserId == ID).ToList();
           return carts;
            
        }
        void ICartService.UpdateCart(Cart cart)
        {
            context.Entry(cart).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

   
        public void DeleteCart(int ID)
        {
            Cart cart = context.Carts.Find(ID);
            context.Entry(cart).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            //context.Categories.Remove(category);
            context.SaveChanges();
        }

        void ICartService.CheckOut(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}
