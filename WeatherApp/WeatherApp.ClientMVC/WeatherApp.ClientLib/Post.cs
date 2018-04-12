using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.ClientLib
{
    public class Post
    {
        [JsonProperty("postID")]
        public int PostID {get; set; }

        [JsonProperty("blogPost")]
        public string BlogPost { get; set; }

        [JsonProperty("imageFile")]
        public string ImageFile { get; set; }

        [JsonProperty("userID")]
        public int UserID { get; set; }

    }
}
