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

        public UserHandler()
        {

        }

        public UserHandler(int id)
        {
            UserID = id;
            _requestString += "/" + UserID.ToString();
        }

        public List<User> GetUserFromDataSvc()
        {
            var drh = new DataSvcRequestHandler();
            return new List<User>() { JsonConvert.DeserializeObject<User>(drh.GetJsonResponse(_requestString)) };
        }

        public List<User> GetAllUsersFromDataSvc()
        {
            _requestString = "http://localhost:9000/api/user";
            var drh = new DataSvcRequestHandler();
            return JsonConvert.DeserializeObject<List<User>>(drh.GetJsonResponse(_requestString));
        }
    }
}
