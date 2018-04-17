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
            Console.WriteLine("\n\n\n\nArrived to Get Index\n\n\n\n");

            var fvm_params = HttpContext.Session.Get<FeedViewModel>("FeedViewModel");

            Console.WriteLine("Zip filter is {0}", fvm_params.ZipCodeFilter);
            var fvm = new FeedViewModel();
            fvm.WeatherTypeFilter = fvm_params.WeatherTypeFilter;
            fvm.ZipCodeFilter = fvm_params.ZipCodeFilter;
            fvm.ApplyPostFilters();

            return View(fvm);
        }

        [HttpPost]
        public ActionResult Index(FeedViewModel model)
        {
            Console.WriteLine("\n\n\n\nArrived to Post Index\n\n\n\n");

            HttpContext.Session.Set<FeedViewModel>("FeedViewModel", model);

            //Put to database here
            return View();
        }
    }
}