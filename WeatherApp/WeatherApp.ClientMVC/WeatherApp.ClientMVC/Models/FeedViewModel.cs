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

        public FeedViewModel()
        {
            var ph = new PostHandler();
            Posts = ph.GetAllPosts();
        }
    }
}
