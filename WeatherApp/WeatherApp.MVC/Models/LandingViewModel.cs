using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Library;

namespace WeatherApp.MVC.Models
{
    public class LandingViewModel
    {
        public User User { get; set; }

        public RootObject HomeZipRootObject { get; set; }

        public LandingViewModel(User u)
        {
            User = u;
            
            var jr = new JsonReader(User.HomeZipCode);
            HomeZipRootObject = jr.GetRootObjectForZipCode();

        }


    }
}
