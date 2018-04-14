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
    public class MakeAPostController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View(new MakeAPostViewModel());
        }


        [HttpPost]
        public ActionResult Index(MakeAPostViewModel model)
        {

            return View(new RegisterViewModel());
        }

    }
}
