using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.DataSvc.WeatherApp.DB;

namespace WeatherApp.DataSvc.Controllers
{

    [Route("api/[controller]")]
    public class PostController : Controller
    {

        private static WeatherAppContext context;

        public PostController(WeatherAppContext db)
        {
            context = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> Get()
        {
            return await Task.Run(() => { return context.Posts.ToList(); });
        }

        [HttpGet("{id}")] // here must put in /<idvalue> to get user
        public async Task<Post> Get(string id)
        {
            int postID = 1;
            if (Int32.TryParse(id, out postID))
                return await Task.Run(() =>
                {
                    return context.Posts.Where(p => p.PostID == postID).FirstOrDefault();
                });
            return await Task.Run(() => { return context.Posts.ToList().FirstOrDefault(); });
        }
    }
}