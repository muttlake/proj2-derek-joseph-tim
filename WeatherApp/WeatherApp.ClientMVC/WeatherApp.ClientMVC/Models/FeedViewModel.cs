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
        public string ZipCodeFilter { get; set; }


        public int ZipCodeInt { get; set; }

        public FeedViewModel()
        {
            var ph = new PostHandler();
            Posts = ph.GetAllPosts();
        }

        public void ApplyPostFilters()
        {
            if (WeatherTypeFilter != null)
            {
                ApplyWeatherTypeFilter();
            }
            if (ZipCodeFilter != null && SetZipCode())
            {
                ApplyZipCodeFilter();
            }
        }

        public bool SetZipCode()
        {
            var valid = Int32.TryParse(ZipCodeFilter, out int zip);
            if (valid)
                ZipCodeInt = zip;
            return valid;
        }

        public void ApplyZipCodeFilter()
        {
            Console.WriteLine("Applying Zip Filer with zipcode: {0}", ZipCodeInt);
            var filteredPosts = new List<Post>();
            foreach (var post in filteredPosts)
            {
                if (post.ZipCode == ZipCodeInt)
                {
                    filteredPosts.Add(post);
                }
            }
            Posts = filteredPosts;
        }


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
