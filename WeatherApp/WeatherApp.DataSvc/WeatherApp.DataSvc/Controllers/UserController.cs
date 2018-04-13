using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherApp.DataSvc.WeatherApp.DB;

namespace WeatherApp.DataSvc.Controllers
{
    [EnableCors("allowAll")] //Enable Cross Origin Resource Sharing
    [Produces("application/json")] // Means every action result will always be a json type result
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private static WeatherAppContext context;

        public UserController(WeatherAppContext db)
        {
            context = db;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await Task.Run(() => { return context.Users.ToList(); });
        }


        [HttpGet("{id}")] // here must put in /<idvalue> to get user
        public async Task<User> Get(string id)
        {
            int userID = 1;
            if (Int32.TryParse(id, out userID))
                return await Task.Run(() =>
                {
                    return context.Users.Where(p => p.UserID == userID).FirstOrDefault();
                });
            return await Task.Run(() => { return context.Users.ToList().FirstOrDefault(); });
        }

        [HttpPost]
        public void ReceiveNewUserAndPutInDatabase()
        {
            Console.WriteLine("\n\n\nReceiveNewUserAndPutInDatabase");


            //Receive from ClientMVC
            Console.WriteLine("From LibSvc's Post:\n");
            var request_Body = new StreamReader(Request.Body).ReadToEnd();
            Console.WriteLine("request_Body: {0}", request_Body);

            //Add New User to Database
            var user = JsonConvert.DeserializeObject<List<User>>(request_Body)[0];
            using (var dbContext = new WeatherAppContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }

        // POST api/user
        //[HttpPost]
        //public IHttpActionResult Post(User user)
        //{
        //    context.Users.Add(user);
        //    context.SaveChanges();
        //    return Ok();
        //}


    }
}