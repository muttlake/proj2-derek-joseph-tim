using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.ClientLib;
using Newtonsoft.Json;

namespace WeatherApp.ClientMVC.Models
{
    public class PostWithWeather
    {
        public Post Post { get; set; }
        public RootObject Weather { get; set; }
    }
    public class LandingViewModel
    {
        public User User { get; set; }
        public List<Post> Posts { get; set; }
        public List<PostWithWeather> PostsWithWeather { get; set; }
        public RootObject HomeZipRootObject { get; set; }
        public string WeatherIcon { get; set; }

        public LandingViewModel(User u)
        {
            User = u;
            
            var jr = new JsonHandler(User.HomeZipCode);
            HomeZipRootObject = jr.GetRootObjectFromLibSvc();
            SetWeatherIcon();
            GetPosts();
            PostsWithWeather = GetPostsWithWeather();
        }

        public void GetPosts()
        {
            var ph = new PostHandler();
            Posts = new List<Post>();
            foreach (var post in ph.GetAllPosts())
            {
                if (post.UserID == User.UserID)
                {
                    Posts.Add(post);
                }
            }
        }

        public RootObject GetCurrentWeather()
        {
            return HomeZipRootObject;
        }

        public void SetWeatherIcon()
        {
            WeatherIcon = "http://openweathermap.org/img/w/" + HomeZipRootObject.weather[0].icon + ".png";
        }

        public List<PostWithWeather> GetPostsWithWeather()
         {
             var postsWithWeather = new List<PostWithWeather>();
             foreach(var post in Posts)
             {
                 var p = new PostWithWeather();
                 p.Post = post;
                 p.Weather = JsonConvert.DeserializeObject<RootObject>(post.WeatherJson);

             }
             return postsWithWeather;
         }
    }
}
