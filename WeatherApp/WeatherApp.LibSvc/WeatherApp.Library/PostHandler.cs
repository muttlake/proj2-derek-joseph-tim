using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WeatherApp.Library
{
    public class PostHandler
    {
        //This is the url to the data service
        private readonly string _requestString;

        public int PostID { get; set; }

        public PostHandler()
        {
            var ash = new AppSettingsHandler();
            _requestString = ash.JsonObject.DatabasePath;
        }

        public PostHandler(int id)
        {
            PostID = id;
            var ash = new AppSettingsHandler();
            _requestString = ash.JsonObject.DatabasePath;
        }

        public List<Post> GetPostFromDataSvc()
        {
            var drh = new DataSvcRequestHandler();
            return new List<Post>() { JsonConvert.DeserializeObject<Post>(drh.GetJsonResponse("http://52.15.149.129/DataSvc/api/post" + PostID.ToString()).GetAwaiter().GetResult()) };
        }

        public List<Post> GetAllPostsFromDataSvc()
        {
            var drh = new DataSvcRequestHandler();
            return JsonConvert.DeserializeObject<List<Post>>(drh.GetJsonResponse("http://52.15.149.129/DataSvc/api/post").GetAwaiter().GetResult());
        }

    }
}
