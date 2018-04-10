using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using demo.MVC.Class;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherApp.MVC.Models;

namespace WeatherApp.MVC.Controllers
{
    public class OpenWeatherMapController : Controller
    {
        public OpenWeatherMap FillCity()
        {
            OpenWeatherMap openWeatherMap = new OpenWeatherMap { Cities = new Dictionary<string, string>() };
            openWeatherMap.Cities.Add("Tampa", "4174757");
            openWeatherMap.Cities.Add("Auckland", "2193734");
            openWeatherMap.Cities.Add("New Delhi", "1261481");
            openWeatherMap.Cities.Add("Abu Dhabi", "292968");
            openWeatherMap.Cities.Add("Lahore", "1172451");
            return openWeatherMap;
        }

        public IActionResult Index()
        {
            OpenWeatherMap openWeatherMap = FillCity();
            return View(openWeatherMap);
        }

        [HttpPost]
        public ActionResult Index(OpenWeatherMap openWeatherMap, string cities)
        {
            openWeatherMap = FillCity();

            if (cities != null)
            {
                /*Calling API http://openweathermap.org/api */
                string apiKey = "";
                HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?id=" + cities + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;

                string apiResponse = "";
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                }
                /*End*/

                /*http://json2csharp.com*/
                ResponseWeather rootObject = JsonConvert.DeserializeObject<ResponseWeather>(apiResponse);

                StringBuilder sb = new StringBuilder();
                sb.Append("<table><tr><th>Weather Description</th></tr>");
                sb.Append("<tr><td>City:</td><td>" + rootObject.Name + "</td></tr>");
                sb.Append("<tr><td>Country:</td><td>" + rootObject.Sys.Country + "</td></tr>");
                sb.Append("<tr><td>Wind:</td><td>" + rootObject.Wind.Speed + " Km/h</td></tr>");
                sb.Append("<tr><td>Current Temperature:</td><td>" + rootObject.Main.Temp + " °C</td></tr>");
                sb.Append("<tr><td>Humidity:</td><td>" + rootObject.Main.Humidity + "</td></tr>");
                sb.Append("<tr><td>Weather:</td><td>" + rootObject.Weather[0].Description + "</td></tr>");
                sb.Append("</table>");
                openWeatherMap.ApiResponse = sb.ToString();
            }
            else
            {
               string sub = Request.Form["submit"];
               if (sub != null)
                {
                    openWeatherMap.ApiResponse = "► Select City";
                }
            }
            return View(openWeatherMap);
        }
    }
}
