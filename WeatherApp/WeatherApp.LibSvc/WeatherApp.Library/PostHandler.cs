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
    public int PostID { get; set; }

    public PostHandler()
    {
      var ash = new AppSettingsHandler();
      string _requestString = ash.JsonObject.DatabasePath;
    }

<<<<<<< HEAD
    public PostHandler(int id)
    {
      PostID = id;
      var ash = new AppSettingsHandler();
      string _requestString = ash.JsonObject.DatabasePath;
    }

    public List<Post> GetPostFromDataSvc()
    {
      var drh = new DataSvcRequestHandler();
      return new List<Post>() { JsonConvert.DeserializeObject<Post>(drh.GetJsonResponse("http://52.15.149.129/DataSvc/api/post" + PostID.ToString()).GetAwaiter().GetResult()) };
    }
=======
        public static async Task<List<Post>> GetPostFromDataSvcAsync(int postid)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://52.15.149.129/DataSvc/api/post/" + postid.ToString());

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
            var result = await client.GetAsync("http://52.15.149.129/DataSvc/api/post");

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Post>>(await result.Content.ReadAsStringAsync());
            }
            else
                return null;

        }
>>>>>>> master

    public List<Post> GetAllPostsFromDataSvc()
    {
      var drh = new DataSvcRequestHandler();
      return JsonConvert.DeserializeObject<List<Post>>(drh.GetJsonResponse("http://52.15.149.129/DataSvc/api/post").GetAwaiter().GetResult());
    }

  }
}
