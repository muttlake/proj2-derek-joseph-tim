using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.ClientLib
{
    public class PostHandler
    {
        //This is the url to the library service
        private readonly string _requestString;

        public int PostID { get; set; }

        public PostHandler()
        {
            var ash = new AppSettingsHandler();
            _requestString = ash.JsonObject.LibraryPath;
        }

        public PostHandler(int id)
        {
            PostID = id;
            var ash = new AppSettingsHandler();
            _requestString = ash.JsonObject.LibraryPath;
        }

        public Post GetPostFromDataSvc()
        {
            var drh = new LibSvcRequestHandler();
            Console.WriteLine(_requestString + "/api/postlib/" + PostID.ToString());
            return JsonConvert.DeserializeObject<Post>(drh.GetJsonResponse(_requestString + "/api/postlib/" + PostID.ToString()).GetAwaiter().GetResult());
        } 

        public List<Post> GetAllPosts()
        {
            var drh = new LibSvcRequestHandler();
            Console.WriteLine(_requestString + "/api/postlib");
            return JsonConvert.DeserializeObject<List<Post>>(drh.GetJsonResponse(_requestString + "/api/postlib").GetAwaiter().GetResult());
        }

        public async void AddPost(User user, RootObject currentWeather, string imageFile, string blogPost)
        {

            var ct = Convert.ToInt32(currentWeather.main.temp);
            var cwj = JsonConvert.SerializeObject(currentWeather);
            var cwd = currentWeather.weather[0].description;


            var post = new Post(blogPost, imageFile, user.UserID, ct, cwj, cwd, user.HomeZipCode);

            // Get the posted form values and add to list using model binding
            List<Post> postData = new List<Post>() { post };

            using (var client = new HttpClient())
            {

                var stringContent = new StringContent(JsonConvert.SerializeObject(postData));
                var uri = new Uri(_requestString + "/api/postlib");
                var response = await client.PostAsync(uri, stringContent);

            }
        }
    }
}
