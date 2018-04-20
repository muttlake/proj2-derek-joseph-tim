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
        private readonly string _requestString;

        public int UserID { get; set; }

        public UserHandler()
        {
            var ash = new AppSettingsHandler();
            _requestString = ash.JsonObject.DatabasePath;
        }

        public UserHandler(int id)
        {
            UserID = id;
            var ash = new AppSettingsHandler();
            _requestString = ash.JsonObject.DatabasePath;
        }

        public List<User> GetUserFromDataSvc()
        {
            var drh = new DataSvcRequestHandler();
            return new List<User>() { JsonConvert.DeserializeObject<User>(drh.GetJsonResponse("http://52.15.149.129/DataSvc/api/user/" + UserID.ToString()).GetAwaiter().GetResult()) };
        }

        public List<User> GetAllUsersFromDataSvc()
        {
            var drh = new DataSvcRequestHandler();
            return JsonConvert.DeserializeObject<List<User>>(drh.GetJsonResponse("http://52.15.149.129/DataSvc/api/user").GetAwaiter().GetResult());
        }
    }
}
