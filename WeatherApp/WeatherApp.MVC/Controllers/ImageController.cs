using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Library;

namespace WeatherApp.MVC.Controllers
{
    public class ImageController : Controller
    {
        [HttpPost]
        public IActionResult Add()
        {
           // AWSConfig aws = new AWSConfig();
            AWSS3Operations s3 = AWSS3Operations();
            
            s3.WriteAnObject(AWSConfig.GetCredentials, "joeaws1", "test","image", )
            return View();
        }
    }
}