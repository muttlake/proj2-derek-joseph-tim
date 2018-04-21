using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Library
{
    public class DataSvcRequestHandler
    {
        public async Task<string> GetJsonResponse(string requestURL)
        {

            HttpWebRequest apiRequest = WebRequest.Create(requestURL) as HttpWebRequest;

            string jsonResponse = "";

            HttpWebResponse response;
            response = await apiRequest.GetResponseAsync() as HttpWebResponse;

            StreamReader reader = new StreamReader(response.GetResponseStream());
            jsonResponse = reader.ReadToEnd();

            Console.WriteLine(jsonResponse);

            return jsonResponse;
        }


       // public static async Task<List<Team>> GetAllTeams()

       // {

       //     var client = new HttpClient();

       //     var result = await client.GetAsync("http://18.219.103.23/data/data/team"); if (result.IsSuccessStatusCode)

       //     {

       //         return JsonConvert.DeserializeObject<List<Team>>(await result.Content.ReadAsStringAsync());

       //     }

       //     else return null;

       // }


       // [HttpGet]

       //public async Task<List<Stats>> GetStatsAsync()

       // {
       //     return await StatsHelper.GetStats();

       // }

    }
}
