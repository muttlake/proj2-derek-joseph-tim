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

                var uh = new UserHandler();
                uh.AddUser(model.usr);

                return RedirectToAction("Index", "Landing");
            }
            return View(new RegisterViewModel());
        }


        // // Old Http post for Index
        // [HttpPost]
        //public IActionResult Index(RegisterViewModel model)
        //{

        //    if (model.AddUser())
        //    {
        //        HttpContext.Session.Set<User>("User", model.usr);
        //        return RedirectToAction("Index", "Landing");

        //    }
        //    return View(new RegisterViewModel());
        //}
    }
}