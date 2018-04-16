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
            var fvm = new FeedViewModel();
            fvm.WeatherTypeFilter = model.WeatherTypeFilter;
            fvm.ZipCodeFilter = model.ZipCodeFilter;
            fvm.ApplyPostFilters();

            //Put to database here
            return View(fvm);
        }
    }
}