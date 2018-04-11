using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Library;
using WeatherApp.MVC.Models;

namespace WeatherApp.MVC.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Console.WriteLine("test");
            return View(new RegisterViewModel());
        }

         [HttpPost]
        public IActionResult Index(RegisterViewModel model)
        {

            if (model.AddUser())
            {
                HttpContext.Session.Set<User>("User", model.usr);
                return RedirectToAction("Index", "Landing");
                
            }
            return View(new RegisterViewModel());
        }


    } 
}