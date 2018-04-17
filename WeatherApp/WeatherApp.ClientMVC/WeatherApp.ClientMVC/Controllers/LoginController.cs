using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.ClientLib;
using WeatherApp.ClientMVC.Models;

namespace WeatherApp.ClientMVC.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            Console.WriteLine(model.Email);
            Console.WriteLine(model.Password);
            if(model.IsUserValid())
            {
                HttpContext.Session.Set<User>("User", model.GetUser());
                HttpContext.Session.Set<FeedViewModel>("FeedViewModel", new FeedViewModel());

                return RedirectToAction("Index", "Landing");
            } 

            return View(new LoginViewModel());
        }
    }
}