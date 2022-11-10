using ClothZone.Models;
using ClothZone.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClothZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;

        public HomeController(ILogger<HomeController> logger, IProductsService productsService, ICategoriesService categoriesService)
        {
            _logger = logger;
            _productsService = productsService;
            _categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            ViewData["Products"] = _productsService.GetProducts();
            ViewData["Categories"] = _categoriesService.GetCategories();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}