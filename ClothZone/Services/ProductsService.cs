using ClothZone.Models;

namespace ClothZone.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ECContext context;

        public ProductsService(ECContext context)
        {
            this.context = context;
        }

        void IProductsService.SaveProduct(Product product)
        {
            //Category category = new Category();
            //product.Category = category;
            //Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Product> entityEntry = context.Products.Add(product);
            //context.SaveChanges();
            Product productToUpdate = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Image = product.Image,
                CategoryId = product.CategoryId,
            };
            context.Products.Add(productToUpdate);
            context.SaveChanges();

        }

        List<Product> IProductsService.GetProducts()
        {
            return context.Products.ToList();
        }

        Product IProductsService.GetProduct(int ID)
        {
            return context.Products.Find(ID);
        }

        void IProductsService.UpdateProduct(Product product)
        {
            context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

   
        public void DeleteProduct(int ID)
        {
            Product product = context.Products.Find(ID);
            context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            //context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
