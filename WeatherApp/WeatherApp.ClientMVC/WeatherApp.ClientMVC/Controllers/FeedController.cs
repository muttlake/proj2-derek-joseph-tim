using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.ClientLib;
using WeatherApp.ClientMVC.Models;

namespace WeatherApp.ClientMVC.Controllers
{
    public class FeedController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View(new FeedViewModel());
        }

        [HttpPost]
        public ActionResult Index(FeedViewModel model)
        {
            var fvm = model;
            if(model.WeatherTypeFilter != null)
            {
                fvm.ApplyWeatherTypeFilter();
            }
            if(model.ZipCodeFilter != null && model.SetZipCode())
            {
                fvm.ApplyZipCodeFilter();
            }

            //Put to database here
            return View(fvm);
        }
    }
}