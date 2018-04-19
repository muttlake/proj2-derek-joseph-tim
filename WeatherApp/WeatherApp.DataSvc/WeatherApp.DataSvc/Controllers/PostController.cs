using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherApp.DataSvc.WeatherApp.DB;

namespace WeatherApp.DataSvc.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")] // Means every action result will always be a json type result
    public class PostController : Controller
    {

        private readonly WeatherAppContext context;

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

        [HttpPost]
        public void ReceiveNewPostAndPutInDatabase()
        {
            //Receive from ClientMVC
            var request_Body = new StreamReader(Request.Body).ReadToEnd();

            //Add New User to Database
            var post = JsonConvert.DeserializeObject<List<Post>>(request_Body)[0];
            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}