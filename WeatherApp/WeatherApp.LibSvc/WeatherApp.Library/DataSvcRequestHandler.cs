using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Library
{
    [Produces("application/json")] // Means every action result will always be a json type result
    public class DataSvcRequestHandler
    {
        public async Task<string> GetJsonResponse(string requestURL)
        {
            HttpWebRequest apiRequest = WebRequest.Create(requestURL) as HttpWebRequest;

            string jsonResponse = "";
            using (HttpWebResponse response = await apiRequest.GetResponseAsync() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonResponse = reader.ReadToEnd();
            }
            Console.WriteLine(jsonResponse);

            return jsonResponse;
        }

    }
}
