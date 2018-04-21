using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.ClientLib
{
    public class UserHandler
    {
        //url of the library service for user
        private readonly string _requestString;

        public int UserID { get; set; }

        public UserHandler()
        {
            var ash = new AppSettingsHandler();
            _requestString = ash.JsonObject.LibraryPath;
        }

        public UserHandler(int id)
        {
            UserID = id;

            var ash = new AppSettingsHandler();
            _requestString = ash.JsonObject.LibraryPath;
        }

        public static async Task<User> GetUserFromLibSvcAsync(int uid)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://52.15.149.129/LibSvc/api/userlib?uid" + uid.ToString());

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync());
            }
            else
                return null;
        }

        public static async Task<List<User>> GetAllUsersFromLibSvcAsync()
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://52.15.149.129/LibSvc/api/userlib");

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<User>>(await result.Content.ReadAsStringAsync());
            }
            else
                return null;

        }

        public static async Task<User> ValidateUser(string email, string password)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("http://52.15.149.129/LibSvc/api/userlib");


            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(content);
                foreach(var user in users)
                {
                    if(user.Email == email && user.Password == password)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        //public static async Task<User> SignIn(string email)
        //{
        //    if (email == null || email == string.Empty)
        //    {
        //        return null;
        //    }
        //    var client = new HttpClient();
        //    var url = "http://13.59.35.94/chatbotdata/api/data/" + email;
        //    var result = await client.GetAsync(new Uri(url));

        //    if (result.IsSuccessStatusCode)
        //    {
        //        var content = await result.Content.ReadAsStringAsync();
        //        var user = JsonConvert.DeserializeObject<User>(content);
        //        return user;
        //    }

        //    return null;
        //}


        public User GetCurrentUser(string email)
        {
            foreach (var user in GetAllUsersFromLibSvcAsync().GetAwaiter().GetResult())
            {
                if (user.Email.Equals(email))
                    return user;
            }

            return new User();
        }

        public async void AddUser(User user)
        {
            // Get the posted form values and add to list using model binding
            List<User> postData = new List<User>() { user };

            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(postData));
                var uri = new Uri(_requestString + "/api/userlib");
                var response = await client.PostAsync(uri, stringContent);

            }
        }


    }
}
