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
            return View(new MakeAPostViewModel(user));
        }


        [HttpPost]
        public ActionResult Index(MakeAPostViewModel model)
        {
            var user = HttpContext.Session.Get<User>("User");
            user = GetValidUserForNewlyRegistered(user); //Get user with userID for newly registered users
            var currentWeather = HttpContext.Session.Get<RootObject>("CurrentWeather");

            //Add Post
            Console.WriteLine("Make a post right now");
            var ph = new PostHandler();
            ph.AddPost(user, currentWeather, model.NewPost.ImageFile, model.NewPost.BlogPost);

            //Put to database here
            return RedirectToAction("Index", "Landing");
        }

        public User GetValidUserForNewlyRegistered(User user)
        {
            //If user has just registered get their userID
            if (user.UserID == 0)
            {
                var uh = new UserHandler();
                foreach (var u in uh.GetAllUsersFromLibSvc())
                {
                    if (u.Email.Equals(user.Email))
                    {
                        user = u;
                        break;
                    }
                }
            }
            return user;
        }

    }
}
