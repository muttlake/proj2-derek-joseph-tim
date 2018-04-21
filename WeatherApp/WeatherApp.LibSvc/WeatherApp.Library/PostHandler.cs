using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Library
{
    public class PostHandler
    {
        private static AppSettingsHandler ash = new AppSettingsHandler();
        private static readonly string httpString = ash.JsonObject.DatabasePath.ToString();
        public int PostID { get; set; }

        public PostHandler()
        {
            string _requestString = httpString;
        }

        public static async Task<List<Post>> GetPostFromDataSvcAsync(int postid)
        {
            var client = new HttpClient();
<<<<<<< HEAD
            var result = await client.GetAsync(httpString + "/api/post/" + postid.ToString());
=======
            var result = await client.GetAsync("http://18.188.13.94/DataSvc/api/post/" + postid.ToString());
>>>>>>> master

            if (result.IsSuccessStatusCode)
            {
                var post = JsonConvert.DeserializeObject<Post>(await result.Content.ReadAsStringAsync());
                return new List<Post>() { post };
            }
            else
                return null;

        }

        public static async Task<List<Post>> GetAllPostsFromDataSvcAsync()
        {
            var client = new HttpClient();
<<<<<<< HEAD
            var result = await client.GetAsync(httpString + "/api/post/");
=======
            var result = await client.GetAsync("http://18.188.13.94/DataSvc/api/post");
>>>>>>> master

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Post>>(await result.Content.ReadAsStringAsync());
            }
            else
                return null;

        }

        public List<Post> GetAllPostsFromDataSvc()
        {
            var drh = new DataSvcRequestHandler();
            return JsonConvert.DeserializeObject<List<Post>>(drh.GetJsonResponse(httpString + "/api/post/").GetAwaiter().GetResult());
        }

    }
}
