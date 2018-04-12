using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.ClientLib;

namespace WeatherApp.ClientMVC.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            Email = "";
            Password = "";
        }

        public bool IsUserValid()
        {
            //var ef = new EfData();
            //return ef.ValidateUser(Email, Password);
            return true;
        }

        public User GetUser()
        {
            //var ef = new EfData();
            //return ef.ReadUsers().Where(p => p.Email == Email).FirstOrDefault();
            var uh = new UserHandler(2);
            return uh.GetUserFromLibSvc();
        }
    }
}
