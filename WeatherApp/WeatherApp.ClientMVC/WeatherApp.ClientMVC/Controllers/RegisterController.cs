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

            if (model.AddUser())
            {
                HttpContext.Session.Set<User>("User", model.usr);

                // Get the posted form values and add to list using model binding
                List<User> postData = new List<User>() { model.usr };
                Console.WriteLine("Serialized object :::  {0}", JsonConvert.SerializeObject(postData));

                using (var client = new HttpClient())
                {

                    var stringContent = new StringContent(JsonConvert.SerializeObject(postData));
                    Console.WriteLine("StringContent for post");
                    Console.WriteLine(stringContent.ToString());
                    var uri = new Uri("http://localhost:8000/api/userlib");
                    var response = client.PostAsync(uri, stringContent);
                    Console.WriteLine("response result {0}", response.Result);
                    Console.WriteLine("response is completed {0}", response.IsCompletedSuccessfully);

                }

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