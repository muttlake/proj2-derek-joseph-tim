using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WeatherApp.ClientLib
{
    public class PostHandler
    {
        //This is the url to the library service
        private string _requestString = "http://localhost:8000/api/postlib";

        public int PostID { get; set; }


        public PostHandler(int id)
        {
            PostID = id;
            _requestString += "/" + PostID.ToString();
        }

        public Post GetPostFromDataSvc()
        {
            var drh = new LibSvcRequestHandler();
            return JsonConvert.DeserializeObject<Post>(drh.GetJsonResponse(_requestString));
        }


    }
}
