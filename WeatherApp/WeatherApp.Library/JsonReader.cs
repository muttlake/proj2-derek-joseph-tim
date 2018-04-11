

using System;
using System.IO;
using System.Net;

namespace WeatherApp.Library
{
    public class JsonReader
    {
        // Our Key for the Open Weather API
        private readonly string _apiKey = "a6acab0d579d6ac71c21659ff3de726d";

        //api.openweathermap.org/data/2.5/weather?q={city name}
        //api.openweathermap.org/data/2.5/weather?zip=94040,us
        public int ZipCode { get; set; }
        public string WeatherApiResponse { get; set; }

        public JsonReader()
        {
            WeatherApiResponse = "";
            ZipCode = 0;
        }

        public JsonReader(int zip)
        {
            WeatherApiResponse = "";
            ZipCode = zip;
        }


        public void PrintWeatherForZip()
        {
            string requestString = "http://api.openweathermap.org/data/2.5/weather?zip=" + ZipCode.ToString() + ",us&appid=" + _apiKey;

            HttpWebRequest apiRequest = WebRequest.Create(requestString) as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
            Console.WriteLine(apiResponse);
        }

    }
}