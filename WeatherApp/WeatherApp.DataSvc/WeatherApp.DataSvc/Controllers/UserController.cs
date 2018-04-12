using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.DataSvc.WeatherApp.DB;

namespace WeatherApp.DataSvc.Controllers
{
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


    }
}