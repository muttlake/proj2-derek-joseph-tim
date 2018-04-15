using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace WeatherApp.ClientLib
{
    public class PostHandler
    {
        //This is the url to the library service
        private string _requestString = "http://localhost:8000/api/postlib";

        public int PostID { get; set; }

        public PostHandler() { }

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

        public List<Post> GetAllPosts()
        {
            var drh = new LibSvcRequestHandler();
            _requestString = "http://localhost:8000/api/postlib";
            Console.WriteLine("Here is GetAllPosts()...");
            Console.WriteLine(drh.GetJsonResponse(_requestString));
            return JsonConvert.DeserializeObject<List<Post>>(drh.GetJsonResponse(_requestString));
        }

        public async void AddPost(User user, RootObject currentWeather, string imageFile, string blogPost)
        {

            var ct = Convert.ToInt32(currentWeather.main.temp);
            var cwj = JsonConvert.SerializeObject(currentWeather);
            var cwd = currentWeather.weather[0].description;


            var post = new Post(blogPost, imageFile, user.UserID, ct, cwj, cwd, user.HomeZipCode);

            // Get the posted form values and add to list using model binding
            List<Post> postData = new List<Post>() { post };
            Console.WriteLine("Serialized object :::  {0}", JsonConvert.SerializeObject(postData));

            using (var client = new HttpClient())
            {

                var stringContent = new StringContent(JsonConvert.SerializeObject(postData));
                Console.WriteLine("StringContent for post");
                Console.WriteLine(stringContent.ToString());
                var uri = new Uri("http://localhost:8000/api/postlib");
                var response = await client.PostAsync(uri, stringContent);
                Console.WriteLine("response request message {0}", response.RequestMessage);
                Console.WriteLine("response is successStatusCode {0}", response.IsSuccessStatusCode);

            }
        }
    }
}
