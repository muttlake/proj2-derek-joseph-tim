using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

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

        public User GetUserFromLibSvc()
        {
            var drh = new LibSvcRequestHandler();  //Here User should be a List with only one User object
            return JsonConvert.DeserializeObject<List<User>>(drh.GetJsonResponse(_requestString + "/api/userlib?uid=" + UserID.ToString()).GetAwaiter().GetResult())[0];
        }

        public List<User> GetAllUsersFromLibSvc()
        {
            var drh = new LibSvcRequestHandler();  //Here should get list of all Users
            return JsonConvert.DeserializeObject<List<User>>(drh.GetJsonResponse(_requestString + "/api/userlib").GetAwaiter().GetResult());
        }

        public bool ValidateUser(string email, string password)
        {
            foreach(var user in GetAllUsersFromLibSvc())
            {
                if (user.Email.Equals(email) && user.Password.Equals(password))
                    return true;
            }

            return false;
        }


        public User GetCurrentUser(string email)
        {
            foreach (var user in GetAllUsersFromLibSvc())
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
