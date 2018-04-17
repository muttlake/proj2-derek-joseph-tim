﻿using System;
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
        public string ZipCodeFilter { get; set; }
        public string TempFahrFilter { get; set; }

        public List<string> WeatherTypes { get; set; }

        public int ZipCodeInt { get; set; }
        public int TempFahrInt { get; set; }

        public RootObject FeedZipRootObject { get; set; }

      

        public FeedViewModel()
        {
            var ph = new PostHandler();
            Posts = ph.GetAllPosts();
<<<<<<< HEAD
            
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
=======
            GetValidWeatherTypes();
        }

        public FeedViewModel(string temp, string wtype, string zip)
        {
            //Assign filters
            TempFahrFilter = temp;
            WeatherTypeFilter = wtype;
            ZipCodeFilter = zip;

            //Get all posts
            var ph = new PostHandler();
            Posts = ph.GetAllPosts();

            Console.WriteLine("Numer of Posts initially: {0}", Posts.Count);

            //Apply Filters
            ApplyPostFilters();
            GetValidWeatherTypes();
        }

        public void GetValidWeatherTypes()
        {
            WeatherTypes = new List<string>();
            foreach(var post in Posts)
            {
                if (!WeatherTypes.Contains(post.WeatherType))
                    WeatherTypes.Add(post.WeatherType);
            }
        }

        public void ApplyPostFilters()
        {
            if (TempFahrFilter != null && SetTemp())
            {
                ApplyTempFilter();
            }
            Console.WriteLine("Numer of Posts after temp filter: {0}", Posts.Count);

            if (WeatherTypeFilter != null && WeatherTypeFilter != "")
            {
                ApplyWeatherTypeFilter();
            }
            Console.WriteLine("Numer of Posts after weather type filter: {0}", Posts.Count);

            if (ZipCodeFilter != null && SetZipCode())
            {
                ApplyZipCodeFilter();
            }
            Console.WriteLine("Numer of Posts after zip code filter: {0}", Posts.Count);


        }

        public bool SetZipCode()
        {
            var valid = Int32.TryParse(ZipCodeFilter, out int zip);
            if (valid)
                ZipCodeInt = zip;
            return valid;
        }

        public bool SetTemp()
        {
            var valid = Int32.TryParse(TempFahrFilter, out int temp);
            if (valid)
                TempFahrInt = temp;
            return valid;
        }


        public void ApplyZipCodeFilter()
        {
            Console.WriteLine("Applying Zip Filer with zipcode: {0}", ZipCodeInt);
            var filteredPosts = new List<Post>();
            foreach (var post in Posts)
            {
                if (post.ZipCode == ZipCodeInt)
                {
                    filteredPosts.Add(post);
                }
            }
            Posts = filteredPosts;
        }

>>>>>>> master

        public void ApplyWeatherTypeFilter()
        {
            var filteredPosts = new List<Post>();
            foreach(var post in Posts)
            {
                if(post.WeatherType.Equals(WeatherTypeFilter))
                {
                    filteredPosts.Add(post);
                }
            }
            Posts = filteredPosts;
        }


<<<<<<< HEAD

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
=======
        public void ApplyTempFilter()
        {
            var filteredPosts = new List<Post>();
            foreach (var post in Posts)
            {
                if (post.TempFahr  >= (TempFahrInt - 2) && post.TempFahr <= (TempFahrInt + 2))
                {
                    filteredPosts.Add(post);
                }
            }
            Posts = filteredPosts;
        }
>>>>>>> master
    }
}
