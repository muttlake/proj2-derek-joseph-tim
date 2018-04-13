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


        public PostHandler(int id)
        {
            PostID = id;
            _requestString += "/" + PostID.ToString();
        }

        public Post GetPostFromDataSvc()
        {
            var drh = new DataSvcRequestHandler();
            return JsonConvert.DeserializeObject<Post>(drh.GetJsonResponse(_requestString));
        }


    }
}
