using ClothZone.Models;
using ClothZone.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Security.Claims;

namespace ClothZone.Controllers
{
    public class AccountController : Controller
    {
        private readonly ECContext context;
        private readonly IUserService _userSevice;
        List<Product> products;
        public AccountController(ECContext context, IUserService UserService)
        {
            this.context = context;
            _userSevice = UserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(LoginViewModel user)
        {
            var Users = _userSevice.GetUsers();
            if (user.UserName == "admin" && user.Password == "admin")
            {
                foreach (User item in Users)
                {
                    if (item.UserName == user.UserName && item.Password == user.Password)
                    {
                        HttpContext.Session.SetString("username", user.UserName);
                        HttpContext.Session.SetInt32("uid", item.Id);
                        HttpContext.Session.SetString("isremember", "true");
                        return RedirectToAction("Index", "Admin");
                    }

                }
            }
            else
            {
                //var Users = _userSevice.GetUsers();
                foreach (User item in Users)
                {
                    if (item.UserName == user.UserName && item.Password == user.Password)
                    {
                        HttpContext.Session.SetString("username", user.UserName);
                        HttpContext.Session.SetInt32("uid", item.Id);
                        HttpContext.Session.SetString("isremember", "true");
                        return RedirectToAction("Index", "Home");
                    }

                }
                return RedirectToAction("SignUp");
            }
            return RedirectToAction("SignUp");
        }

        public IActionResult LogOut()
        {
            //HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //HttpContext.Session.SetString("username",null);
            //HttpContext.Session.SetInt32("uid",null);
            //HttpContext.Session.SetString("isremember", null);
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("uid");
            HttpContext.Session.Remove("isremember");
            return RedirectToAction("SignIn","Account");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if(ModelState.IsValid)
            {
                  context.Users.Add(user);
                  context.SaveChanges();
                 TempData["succesMessage"] = "You are eligible to login, Please fill own credentials and then login";
                 return RedirectToAction("SignIn");
          
            }
            else
            {
                TempData["succesMessage"] = "Empty form can't be submitted!";
                return View(user);
            }
        }
    }
}
