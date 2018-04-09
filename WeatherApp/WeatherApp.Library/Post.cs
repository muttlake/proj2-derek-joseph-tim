using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Library
{
    public class Post
    {
        [Key]
        public int PostID {get; set; }

	public string BlogPost { get; set; }
	public string ImageFile { get; set; }

        public Post()
        {
        }


	//Foreign Key for User
	public int UserID { get; set; }
	public User User { get; set; }

    }
}
