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
            Console.WriteLine("\n\n\nReceiveNewPostAndPutInDatabase");


            //Receive from ClientMVC
            Console.WriteLine("From LibSvc's Post:\n");
            var request_Body = new StreamReader(Request.Body).ReadToEnd();
            Console.WriteLine("request_Body: {0}", request_Body);

            //Add New User to Database
            var post = JsonConvert.DeserializeObject<List<Post>>(request_Body)[0];
            //using (var dbContext = new WeatherAppContext())
            //{
            //    dbContext.Posts.Add(post);
            //    dbContext.SaveChanges();
            //}

            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}