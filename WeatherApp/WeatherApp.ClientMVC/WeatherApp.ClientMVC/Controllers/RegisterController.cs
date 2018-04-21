using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.ClientLib;
using WeatherApp.ClientMVC.Models;
using Newtonsoft.Json;

namespace WeatherApp.ClientMVC.Controllers
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
        public ActionResult Index(RegisterViewModel model)
        {
            if (model.CanAddUser())
            {
                HttpContext.Session.Set<User>("User", model.usr);

                var user = UserHandler.AddUser(model.usr).GetAwaiter().GetResult();
                if( user != null)
                {
                    return RedirectToAction("Index", "Landing");
                }
                else
                {
                    Console.WriteLine("Failed to Add User");
                }
            }
            return View(new RegisterViewModel());
        }
    }
}