using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace WeatherApp.Library
{
    public class JsonReader
    {
        // Our Key for the Open Weather API
        private readonly string _apiKey = "a6acab0d579d6ac71c21659ff3de726d";

        //api.openweathermap.org/data/2.5/weather?q={city name}
        //api.openweathermap.org/data/2.5/weather?zip=94040,us
        public int InputZipCode { get; set; }
        public string WeatherApiResponse { get; set; }

        public RootObject RootObject { get; set; }

        public JsonReader()
        {
            WeatherApiResponse = "";
            InputZipCode = 0;
        }

        public JsonReader(int zip)
        {
            WeatherApiResponse = "";
            InputZipCode = zip;
        }


        public void PrintWeatherForZip()
        {
            string requestString = "http://api.openweathermap.org/data/2.5/weather?zip=" + InputZipCode.ToString() + ",us&appid=" + _apiKey;

            HttpWebRequest apiRequest = WebRequest.Create(requestString) as HttpWebRequest;

            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                WeatherApiResponse = reader.ReadToEnd();
            }
            Console.WriteLine(WeatherApiResponse);
        }

        public void MakeRootObject()
        {
            RootObject = JsonConvert.DeserializeObject<RootObject>(WeatherApiResponse);
        }

        public RootObject GetRootObjectForZipCode()
        {
            string requestString = "http://api.openweathermap.org/data/2.5/weather?zip=" + InputZipCode.ToString() + ",us&appid=" + _apiKey;

            HttpWebRequest apiRequest = WebRequest.Create(requestString) as HttpWebRequest;

            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                WeatherApiResponse = reader.ReadToEnd();
            }
            Console.WriteLine(WeatherApiResponse);

            return JsonConvert.DeserializeObject<RootObject>(WeatherApiResponse);
        }

    }
}