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

        public static async Task<Post> GetPostFromDataSvcAsync(int pid)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://52.15.149.129/LibSvc/api/postlib?pid" + pid.ToString());

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Post>(await result.Content.ReadAsStringAsync());
            }
            else
                return null;
        } 

        public static async Task<List<Post>> GetAllPostsAsync()
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://52.15.149.129/LibSvc/api/postlib");

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Post>>(await result.Content.ReadAsStringAsync());
            }
            else
                return null;
        }

        public static async Task<Post> AddPost(User user, RootObject currentWeather, string imageFile, string blogPost)
        {

            var ct = Convert.ToInt32(currentWeather.main.temp);
            var cwj = JsonConvert.SerializeObject(currentWeather);
            var cwd = currentWeather.weather[0].description;
            var post = new Post(blogPost, imageFile, user.UserID, ct, cwj, cwd, user.HomeZipCode);


            List<Post> postData = new List<Post>() { post };
            var data = JsonConvert.SerializeObject(postData);
            var stringContent = new StringContent(data);

            var uri = new Uri("http://52.15.149.129/LibSvc/api/postlib");
            var client = new HttpClient();
            var result = await client.PostAsync(uri, stringContent);

            if (result.IsSuccessStatusCode)
            {
                return post;
            }

            return null;
        }
    }
}
