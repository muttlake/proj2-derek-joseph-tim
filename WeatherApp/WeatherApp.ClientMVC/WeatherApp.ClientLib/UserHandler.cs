using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WeatherApp.ClientLib
{
    public class UserHandler
    {
        //url of the library service for user
        private string _requestString = "http://localhost:8000/api/userlib";

        public int UserID { get; set; }


        public UserHandler(int id)
        {
            UserID = id;
            _requestString += "?uid=" + UserID.ToString();
        }

        public User GetUserFromLibSvc()
        {
            var drh = new LibSvcRequestHandler();
            return JsonConvert.DeserializeObject<User>(drh.GetJsonResponse(_requestString));
        }
    }
}
