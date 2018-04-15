using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.ClientLib;
using WeatherApp.ClientMVC.Models;

namespace WeatherApp.ClientMVC.Controllers
{
    public class LandingController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var user = HttpContext.Session.Get<User>("User");
            return View(new LandingViewModel(user));
        }

        [HttpPost]
        public IActionResult MakePost()
        {
            return View(new PostViewModel());
        }
    }
}