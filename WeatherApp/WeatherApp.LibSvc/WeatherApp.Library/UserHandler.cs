using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Library
{
  public class UserHandler
  {
    public int UserID { get; set; }
    
    public UserHandler()
    {
        private readonly string _requestString;

        public int UserID { get; set; }

        public UserHandler()
        {
            var ash = new AppSettingsHandler();
            _requestString = ash.JsonObject.DatabasePath;
        }

        public UserHandler(int id)
        {
            UserID = id;
            var ash = new AppSettingsHandler();
            _requestString = ash.JsonObject.DatabasePath;
        }

        public static async Task<List<User>> GetUserFromDataSvcAsync(int userid)
        {

            var client = new HttpClient();
            var result = await client.GetAsync("http://52.15.149.129/DataSvc/api/user/" + userid.ToString());

            if (result.IsSuccessStatusCode)
            {
                var user =  JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync());
                return new List<User>() { user };
            }
            else
                return null;
        }

        public static async Task<List<User>> GetAllUsersFromDataSvcAsync()
        {

            var client = new HttpClient();
            var result = await client.GetAsync("http://52.15.149.129/DataSvc/api/user");

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<User>>(await result.Content.ReadAsStringAsync());
            }
            else
                return null;

        }
    }

    public UserHandler(int id)
    {
      UserID = id;
      var ash = new AppSettingsHandler();
      string _requestString = ash.JsonObject.DatabasePath;
    }

    public async Task<List<User>> GetUserFromDataSvcAsync()
    {

      var client = new HttpClient();
      var result = await client.GetAsync("http://52.15.149.129/DataSvc/api/user/" + UserID.ToString());

      if (result.IsSuccessStatusCode)
      {
        var user = JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync());
        return new List<User>() { user };
      }
      else
        return null;
    }

    public async Task<List<User>> GetAllUsersFromDataSvcAsync()
    {

      var client = new HttpClient();
      var result = await client.GetAsync("http://52.15.149.129/DataSvc/api/user");

      if (result.IsSuccessStatusCode)
      {
        return JsonConvert.DeserializeObject<List<User>>(await result.Content.ReadAsStringAsync());
      }
      else
        return null;

    }
  }
}
