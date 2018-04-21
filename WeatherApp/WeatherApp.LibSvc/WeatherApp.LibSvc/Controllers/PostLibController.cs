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
        public void RelayAddPost()
        {
            var request_Body = new StreamReader(Request.Body).ReadToEnd();

            var ash = new AppSettingsHandler();
            var uri = new Uri("http://52.15.149.129/DataSvc/api/post");

            var rp = new RelayPost();
            rp.RelayAddToDataSvc(uri, request_Body);

        }
    }
}