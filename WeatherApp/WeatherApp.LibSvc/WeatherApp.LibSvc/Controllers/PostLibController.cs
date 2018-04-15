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
    public class PostLibController : Controller
    {
        [HttpGet]
        public async Task<List<Post>> Get(string pid = "default")
        {
            int postID = 1;
            if (Int32.TryParse(pid, out postID))
            {
                return await Task.Run(() =>
                {
                    var ph = new PostHandler(postID);
                    return ph.GetPostFromDataSvc();
                });
            }
            else
                return await Task.Run(() =>
                {
                    var ph = new PostHandler(); // Change this later
                    return ph.GetAllPostsFromDataSvc();
                });
        }

        [HttpPost]
        public async void RelayAddPost()
        {
            Console.WriteLine("\n\n\nRelayAddPost");


            //Receive from ClientMVC
            Console.WriteLine("From ClientMVC's Post:\n");
            var request_Body = new StreamReader(Request.Body).ReadToEnd();
            Console.WriteLine("request_Body: {0}", request_Body);

            //Pass to DataSvc
            using (var client = new HttpClient())
            {

                var stringContent = new StringContent(request_Body);
                Console.WriteLine("StringContent for post");
                Console.WriteLine(stringContent.ToString());
                var uri = new Uri("http://localhost:9000/api/post");
                var response = await client.PostAsync(uri, stringContent);
                Console.WriteLine("response result {0}", response.StatusCode);
                Console.WriteLine("response is completed {0}", response.RequestMessage);

            }

        }
    }
}