using ClothZone.Models;

namespace ClothZone.Services
{
    public interface ICategoriesService
    {
      void SaveCategory(Category category);
      List<Category> GetCategories();
      Category GetCategory(int ID);
      void UpdateCategory(Category category);
      void DeleteCategory(int ID);
    }
}
