using ClothZone.Models;
using ClothZone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;

namespace ClothZone.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;
        private readonly ICartService _cartService;
        List<Product> products;
        
        public ProductController(IProductsService productsService, ICategoriesService categoriesService, ICartService cartService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            //var products = _productsService.GetProducts();
            ViewData["Products"] = _productsService.GetProducts();
            ViewData["Categories"] = _categoriesService.GetCategories();
            //return View(products);
            return View();
        }
        /*[HttpPost]
        public IActionResult Index(Product product)
        {
            _productsService.SaveProduct(product);
            var products = _productsService.GetProducts();
            return View(products);

        }*/
        public IActionResult ProductTable(string search)
        {
            //var products = _productsService.GetProducts();
            //dynamic newModel = new ExpandoObject();
            //newModel.Categories = _categoriesService.GetCategories();
            //newModel.Products = _productsService.GetProducts();
            //if (string.IsNullOrEmpty(search)==false)
            //{
            //    products = products.Where(products => products.Name!= null && products.Name.ToLower().Contains(search.ToLower())).ToList();

            //newModel.sproducts = products;
            //}
            //return PartialView(products);
            ViewData["Products"] = _productsService.GetProducts();
            ViewData["Categories"] = _categoriesService.GetCategories();
            //return View(products);
            return PartialView();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Categories"] = _categoriesService.GetCategories();
            return PartialView();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productsService.SaveProduct(product);
            return RedirectToAction("ProductTable");

        }
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var product = _productsService.GetProduct(ID);

            return PartialView(product);
        }

        public IActionResult ViewProduct(IFormCollection collection)
        {
            ViewData["Products"] = _productsService.GetProducts();
            ViewData["Categories"] = _categoriesService.GetCategories();
            var product = _productsService.GetProduct(Convert.ToInt32(collection["productid"].ToString()));

            return View(product);
        }

       public IActionResult checkout(IFormCollection collection)
        {
 
            var order = new Order();
            order.UserId = (int)HttpContext.Session.GetInt32("uid");
            order.TAmount = long.Parse(collection["amt"]);
            _cartService.CheckOut(order);
            return View();
        }

      /* public IActionResult checkout(long amt)
        {
            var order = new Order();
            order.UserId = (int)HttpContext.Session.GetInt32("uid");
            order.TAmount = amt;
            return View();
        }
      */

        public IActionResult AddToCart(int Id,int Qty)
        {

            if (HttpContext.Session.GetInt32("uid") == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            int Uid = (int)HttpContext.Session.GetInt32("uid");
            if(Qty==0)
            {
                Qty = 1;
            }
            Product product = _productsService.GetProduct(Id);
            Cart cart = new Cart();
            List<Cart> cartl = new List<Cart>();
            cartl = _cartService.GetCarts();
            
            foreach(Cart c in cartl)
            {
                if(c.UserId == Uid)
                {
                    if(c.ProductId == Id)
                    {
                        c.Qty= c.Qty+Qty;
                        _cartService.UpdateCart(c);
                        TempData["message"] = "Product Added";
                        return RedirectToAction("ProductTable");
                    }
                    else
                    {
                        cart.UserId = Uid;
                        cart.Qty = Qty;
                        cart.ProductId = Id;
                        cart.TPrice = (long)(Qty * product.Price);
                        TempData["message"] = "Product Added";
                        _cartService.SaveCart(cart);
                        return RedirectToAction("ProductTable");
                    }

                }
            }
            
                cart.UserId = Uid;
                cart.Qty = Qty;
                cart.ProductId = Id;
                cart.TPrice = (long)(Qty * product.Price);
            TempData["message"] = "Product Added";

            _cartService.SaveCart(cart);
            

            //Ids.Add(Id);
            //Qtys.Add(Qty);
            //ViewBag.Qty = Qty;
            //ViewBag.Id = Id;

            return RedirectToAction("ProductTable");
        }
        public IActionResult ShowCart()
        {
            if(HttpContext.Session.GetInt32("uid")==null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            int uid = (int)HttpContext.Session.GetInt32("uid");

            //var carts = _cartService.GetCartByUser(uid);
            ViewData["Carts"] = _cartService.GetCartByUser(uid);
            ViewData["Products"] = _productsService.GetProducts();
            ViewData["Categories"] = _categoriesService.GetCategories();

            return View();
        }
        [HttpPost]
        public IActionResult Edit(Product product)  
        {
            _productsService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }
       
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            //var category = _categoriesService.GetCategory(ID);
            _productsService.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }


    }



}
