using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WeatherApp.Library
{
    public class UserHandler
    {
        private string _requestString = "http://localhost:9000/api/user";

        public int UserID { get; set; }


        public UserHandler(int id)
        {
            UserID = id;
            _requestString += "/" + UserID.ToString();
        }

        public User GetUserFromDataSvc()
        {
            HttpWebRequest apiRequest = WebRequest.Create(_requestString) as HttpWebRequest;

            string jsonResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                jsonResponse = reader.ReadToEnd();
            }
            Console.WriteLine(jsonResponse);

            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }
    }
}
