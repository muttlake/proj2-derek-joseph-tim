﻿using System;
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
        public string TempFahrFilter { get; set; }

        public List<string> WeatherTypes { get; set; }

        public int ZipCodeInt { get; set; }
        public int TempFahrInt { get; set; }

        public FeedViewModel()
        {
            var ph = new PostHandler();
            Posts = ph.GetAllPosts();
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
    }
}