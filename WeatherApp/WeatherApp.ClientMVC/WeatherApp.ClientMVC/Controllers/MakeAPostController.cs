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
            var user = HttpContext.Session.Get<User>("User");

            //If user has just registered get their userID
            if (user.UserID == 0)
            {
                var uh = new UserHandler();
                foreach(var u in uh.GetAllUsersFromLibSvc())
                {
                    if (u.Email.Equals(user.Email))
                    {
                        user = u;
                        break;
                    }
                }
            }

            HttpContext.Session.Set<User>("User", user);
            var manp = new MakeAPostViewModel(user);

            return View(manp);
        }


        [HttpPost]
        public ActionResult Index(MakeAPostViewModel model)
        {
            var user = HttpContext.Session.Get<User>("User");
            model.NewPost.UserID = user.UserID;

            //Put to database here

            return RedirectToAction("Index", "Landing");

            //return View(new RegisterViewModel());
        }

    }
}
