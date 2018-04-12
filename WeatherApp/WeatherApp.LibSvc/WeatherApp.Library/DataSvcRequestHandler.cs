using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WeatherApp.Library
{
    public class DataSvcRequestHandler
    {
        public string GetJsonResponse(string requestURL)
        {
            HttpWebRequest apiRequest = WebRequest.Create(requestURL) as HttpWebRequest;

            string jsonResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonResponse = reader.ReadToEnd();
            }
            Console.WriteLine(jsonResponse);

            return jsonResponse;
        }
    }
}
