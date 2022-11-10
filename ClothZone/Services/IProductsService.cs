using ClothZone.Models;
using Microsoft.AspNetCore.Mvc;
namespace ClothZone.Services
{
    public interface IProductsService
    {
      void SaveProduct(Product product);
      List<Product> GetProducts();
      Product GetProduct(int ID);
      void UpdateProduct(Product product);
      void DeleteProduct(int ID);
       
    }
}
