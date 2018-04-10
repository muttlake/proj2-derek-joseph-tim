
using System.Collections.Generic;

namespace WeatherApp.MVC.Models
{
    public class OpenWeatherMap
    {
        public string ApiResponse { get; set; }

        public Dictionary<string, string> Cities
        {
            get; set;
        }
    }
}