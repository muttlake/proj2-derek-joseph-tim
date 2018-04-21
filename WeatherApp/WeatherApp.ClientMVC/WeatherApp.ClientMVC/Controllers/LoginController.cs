using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.ClientLib;
using WeatherApp.ClientMVC.Models;

namespace WeatherApp.ClientMVC.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (UserHandler.ValidateUser(model.Email, model.Password))
                {
                    HttpContext.Session.Set<User>("User", model.GetUser());                    
                    return RedirectToAction("Index", "Landing");
                }
            }

            return RedirectToAction("Index", "Home");

        }


      
    }
}
