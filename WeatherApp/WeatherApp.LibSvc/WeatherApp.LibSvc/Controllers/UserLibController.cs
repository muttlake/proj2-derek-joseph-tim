using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Library;

namespace WeatherApp.LibSvc.Controllers
{
    [EnableCors("allowAll")] //Enable Cross Origin Resource Sharing
    [Produces("application/json")] // Means every action result will always be a json type result
    [Route("api/[controller]")]
    public class UserLibController : Controller
    {
        [HttpGet]
        public async Task<List<User>> Get(string uid = "default")
        {
            Console.WriteLine("\n\n\nLibSvc userlib Get");
            int userID = 0;
            if (Int32.TryParse(uid, out userID))
            {
                return await Task.Run(() =>
                {
                    var uh = new UserHandler(userID);
                    return uh.GetUserFromDataSvc();
                });
            }
            else
                return await Task.Run(() =>
                {
                    var uh = new UserHandler(); //Return all users by default
                    return uh.GetAllUsersFromDataSvc();
                });
        }

        [HttpPost]
        public void RelayAddUser()
        {

            var request_Body = new StreamReader(Request.Body).ReadToEnd();
            Console.WriteLine("request_Body: {0}", request_Body);
            var uri = new Uri("http://localhost:9000/api/user");

            var rp = new RelayPost();
            rp.RelayAddToDataSvc(uri, request_Body);
        }

    }
}