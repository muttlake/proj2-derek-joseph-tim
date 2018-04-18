using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WeatherApp.ClientLib
{
    public class JsonHandler
    {
        //url of the library service for ZipWeather
        private readonly string _requestString;

        public int ZipCode { get; set; }


        public JsonHandler(int zip)
        {
            ZipCode = zip;

            var ash = new AppSettingsHandler();
            _requestString += ash.JsonObject.LibraryPath + "/api/zipweather" + "?zip=" + ZipCode.ToString();
        }

        public RootObject GetRootObjectFromLibSvc()
        {
            var drh = new LibSvcRequestHandler();
            return JsonConvert.DeserializeObject<RootObject>(drh.GetJsonResponse(_requestString).GetAwaiter().GetResult());
        }
    }
}
