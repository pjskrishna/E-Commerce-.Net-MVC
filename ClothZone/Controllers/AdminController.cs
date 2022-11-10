using ClothZone.Models;
using ClothZone.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClothZone.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;
        private readonly ICartService _cartService;
        List<Product> products;

        public AdminController(IProductsService productsService, ICategoriesService categoriesService, ICartService cartService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            ViewData["Carts"] = _cartService.GetCartByUser(1);
            ViewData["Products"] = _productsService.GetProducts();
            ViewData["Categories"] = _categoriesService.GetCategories();
            
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productsService.SaveProduct(product);
            return RedirectToAction("ProductList");

        }
        [HttpGet]
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var product = _productsService.GetProduct(ID);

            return PartialView(product);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _productsService.UpdateProduct(product);
            return RedirectToAction("ProductList");
        }
        public IActionResult ProductList(string search)
        {
            var products = _productsService.GetProducts();

            if (string.IsNullOrEmpty(search) == false)
            {
                products = products.Where(products => products.Name != null && products.Name.ToLower().Contains(search.ToLower())).ToList();

            }

            ViewData["Carts"] = _cartService.GetCartByUser(1);
            ViewData["Products"] = _productsService.GetProducts();
            ViewData["Categories"] = _categoriesService.GetCategories();
            return PartialView();
        }
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            //var category = _categoriesService.GetCategory(ID);
            _productsService.DeleteProduct(ID);
            return RedirectToAction("ProductList");
        }

    }
}
