using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WeatherApp.ClientLib;

namespace WeatherApp.ClientMVC.Models
{
    public class MakeAPostViewModel
    {
        public User User { get; set; }
        public Post NewPost { get; set; }

        public MakeAPostViewModel()
        {
            NewPost = new Post();
            NewPost.BlogPost = "";
            NewPost.ImageFile = "";
        }

        public MakeAPostViewModel(User user)
        {
            NewPost = new Post();
            NewPost.BlogPost = "";
            NewPost.ImageFile = "";
            User = user;
            NewPost.UserID = User.UserID;
        }

    }
}
