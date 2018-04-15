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
        private string _requestString = "http://localhost:8000/api/userlib";

        public int UserID { get; set; }

        public UserHandler()
        {

        }

        public UserHandler(int id)
        {
            UserID = id;
            _requestString += "?uid=" + UserID.ToString();
        }

        public User GetUserFromLibSvc()
        {
            var drh = new LibSvcRequestHandler();  //Here User should be a List with only one User object
            return JsonConvert.DeserializeObject<List<User>>(drh.GetJsonResponse(_requestString))[0];
        }

        public List<User> GetAllUsersFromLibSvc()
        {
            _requestString = "http://localhost:8000/api/userlib";
            var drh = new LibSvcRequestHandler();  //Here should get list of all Users
            return JsonConvert.DeserializeObject<List<User>>(drh.GetJsonResponse(_requestString));
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
            Console.WriteLine("Serialized object :::  {0}", JsonConvert.SerializeObject(postData));

            using (var client = new HttpClient())
            {

                var stringContent = new StringContent(JsonConvert.SerializeObject(postData));
                Console.WriteLine("StringContent for post");
                Console.WriteLine(stringContent.ToString());
                var uri = new Uri("http://localhost:8000/api/userlib");
                var response = await client.PostAsync(uri, stringContent);
                Console.WriteLine("response request message {0}", response.RequestMessage);
                Console.WriteLine("response is successStatusCode {0}", response.IsSuccessStatusCode);

            }
        }


    }
}
