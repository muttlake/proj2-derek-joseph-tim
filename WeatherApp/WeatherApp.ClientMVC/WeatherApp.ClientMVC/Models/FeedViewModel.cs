using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.ClientLib;

namespace WeatherApp.ClientMVC.Models
{
    public class FeedViewModel
    {
        public List<Post> Posts { get; set; }

        public string WeatherTypeFilter { get; set; }

        public FeedViewModel()
        {
            var ph = new PostHandler();
            Posts = ph.GetAllPosts();
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
    }
}
