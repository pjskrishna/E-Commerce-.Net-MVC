using ClothZone.Models;
using ClothZone.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClothZone.Controllers
{
    public class CategoryController : Controller,ICategoriesService
    {

        private readonly ICategoriesService _categoriesService;
        public CategoryController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var categories = _categoriesService.GetCategories();
            return View(categories);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoriesService.SaveCategory(category);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
             var category = _categoriesService.GetCategory(ID);
             
            return View(category);
        }


        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _categoriesService.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            Category category = _categoriesService.GetCategory(ID);

            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            //var category = _categoriesService.GetCategory(ID);
            _categoriesService.DeleteCategory(category.Id);
            return RedirectToAction("Index");
        }

        public void SaveCategory(Category category)
        {
            _categoriesService.SaveCategory(category);
        }

        public List<Category> GetCategories()
        {
            return _categoriesService.GetCategories();
        }

        public Category GetCategory(int ID)
        {
            return _categoriesService.GetCategory(ID);
        }

        public void UpdateCategory(Category category)
        {
            _categoriesService.UpdateCategory(category);
        }

        public void DeleteCategory(int ID)
        {
            _categoriesService.DeleteCategory(ID);
        }
    }
}
