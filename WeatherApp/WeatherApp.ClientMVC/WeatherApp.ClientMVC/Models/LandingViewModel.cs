using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.ClientLib;

namespace WeatherApp.ClientMVC.Models
{
    public class LandingViewModel
    {
        public User User { get; set; }
        public Post Post { get; set; }
        public List<Post> Posts { get; set; }

        public NewPost NewPost { get; set; }

        public RootObject HomeZipRootObject { get; set; }

        public LandingViewModel(User u)
        {
            User = u;
            
            var jr = new JsonHandler(User.HomeZipCode);
            HomeZipRootObject = jr.GetRootObjectFromLibSvc();
            GetPosts();
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

        public void MakePost()
        {

        }
    }
}
