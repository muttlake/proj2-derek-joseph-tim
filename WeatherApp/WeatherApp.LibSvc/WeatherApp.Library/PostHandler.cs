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
        private string _requestString = "http://localhost:9000/api/post";

        public int PostID { get; set; }

        public PostHandler()
        {

        }

        public PostHandler(int id)
        {
            PostID = id;
            _requestString += "/" + PostID.ToString();
        }

        public List<Post> GetPostFromDataSvc()
        {
            var drh = new DataSvcRequestHandler();
            return new List<Post>() { JsonConvert.DeserializeObject<Post>(drh.GetJsonResponse(_requestString)) };
        }

        public List<Post> GetAllPostsFromDataSvc()
        {
            _requestString = "http://localhost:9000/api/post";
            var drh = new DataSvcRequestHandler();
            return JsonConvert.DeserializeObject<List<Post>>(drh.GetJsonResponse(_requestString));
        }

    }
}
