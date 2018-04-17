﻿using System;
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

            //var fvm_params = HttpContext.Session.Get<FeedViewModel>("FeedViewModel");

            //Console.WriteLine("Zip filter is {0}", fvm_params.ZipCodeFilter);


            return View(new FeedViewModel());
        }

        [HttpPost]
        public ActionResult Index(FeedViewModel model)
        {
            Console.WriteLine("\n\n\n\nArrived to Post Index\n\n\n\n");

            string temp = "";
            string weatherType = "";
            string zip = "";
            if (model.TempFahrFilter != null)
                temp = model.TempFahrFilter;
            if (model.WeatherTypeFilter != null)
                weatherType = model.WeatherTypeFilter;
            if (model.ZipCodeFilter != null)
                zip = model.ZipCodeFilter;

            Console.WriteLine("Temp Filter {0}", temp);
            Console.WriteLine("Weather Type Filter {0}", weatherType);
            Console.WriteLine("Zip Code Filter {0}", zip);

            var fvm = new FeedViewModel(temp, weatherType, zip);

            //Put to database here
            return View(fvm);
        }
    }
}