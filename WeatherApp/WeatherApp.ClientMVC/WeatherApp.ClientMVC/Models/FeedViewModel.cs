using System;
using System.Collections.Generic;
using WeatherApp.ClientLib;
using Newtonsoft.Json;
namespace WeatherApp.ClientMVC.Models
{
    // public class FeedWithWeather
    // {
    //     public Post Post { get; set; }
    //     public RootObject Feed { get; set; }

    //     public string FeedWeatherIconImage { get; set; }
       
    // }
    public class FeedViewModel
    {
        public User User { get; set; }
        public List<Post> Posts { get; set; }

        public List<PostWithWeather> FeedWithWeather { get; set; }
        public string WeatherTypeFilter { get; set; }

        public RootObject FeedZipRootObject { get; set; }

      

        public FeedViewModel()
        {
            var ph = new PostHandler();
            Posts = ph.GetAllPosts();
            
        }

          public FeedViewModel(User user)
        {
           
            User = user;
            var pr = new JsonHandler(User.HomeZipCode);
            FeedZipRootObject = pr.GetRootObjectFromLibSvc();
            
             GetPostsWithWeather();

        }


        //public void ApplyPostFilters()
        //{
        //    if(WeatherTypeFilter != null)
        //    {
        //        ApplyWeatherTypeFilter();
        //    }
        //}

        public void ApplyWeatherTypeFilter()
        {
            var filteredPosts = new List<Post>();
            foreach(var post in filteredPosts)
            {
                if(post.WeatherType.Equals(WeatherTypeFilter))
                {
                    filteredPosts.Add(post);
                }
            }
            Posts = filteredPosts;
        }



        public RootObject GetCurrentWeather()
        {
            return FeedZipRootObject;
        }

        


         public void GetPostsWithWeather()
         {
             FeedWithWeather = new List<PostWithWeather>();
             foreach(var post in Posts)
             {
                 var p = new PostWithWeather();
                 p.Post = post;
                 p.Weather = JsonConvert.DeserializeObject<RootObject>(post.WeatherJson);
                 p.WeatherIconImage =  "http://openweathermap.org/img/w/" + p.Weather.weather[0].icon + ".png";
               FeedWithWeather.Add(p);

             }
         }
    }
}
