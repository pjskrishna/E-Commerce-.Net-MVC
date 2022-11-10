using ClothZone.Models;

namespace ClothZone.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ECContext context;

        public CategoriesService(ECContext context)
        {
            this.context = context;
        }

        void ICategoriesService.SaveCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        List<Category> ICategoriesService.GetCategories()
        {
            return context.Categories.ToList();
        }

        Category ICategoriesService.GetCategory(int ID)
        {
            return context.Categories.Find(ID);
        }

        void ICategoriesService.UpdateCategory(Category category)
        {
            context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

   
        public void DeleteCategory(int ID)
        { 
            Category category = context.Categories.Find(ID);
            context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            //context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
