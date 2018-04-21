﻿using Newtonsoft.Json;
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
        //private static AppSettingsHandler ash = new AppSettingsHandler();
        //private static readonly string httpString = ash.JsonObject.LibraryPath.ToString();
        private static readonly string httpString = "http://localhost:"

        public int UserID { get; set; }

        public UserHandler()
        {
            var  _requestString = httpString;
        }

        public UserHandler(int id)
        {
            UserID = id;
            var _requestString = httpString;
        }

        public static async Task<User> GetUserFromLibSvcAsync(int uid)
        {
            var client = new HttpClient();
<<<<<<< HEAD
            Uri uri = new Uri(httpString + "/api/userlib");
            var result = await client.GetAsync(uri + "?uid" + uid.ToString());
=======
            var result = await client.GetAsync("http://18.188.13.94/LibSvc/api/userlib?uid" + uid.ToString());
>>>>>>> master

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
<<<<<<< HEAD
            Uri uri = new Uri(httpString + "/api/userlib");
            var result = await client.GetAsync(uri);
=======
            var result = await client.GetAsync("http://18.188.13.94/LibSvc/api/userlib");
>>>>>>> master

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
<<<<<<< HEAD
            Uri uri = new Uri(httpString + "/api/userlib");
            var result = await client.GetAsync(uri);
=======
            var result = await client.GetAsync("http://18.188.13.94/LibSvc/api/userlib");
>>>>>>> master


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

        public User GetCurrentUser(string email)
        {
            foreach (var user in GetAllUsersFromLibSvcAsync().GetAwaiter().GetResult())
            {
                if (user.Email.Equals(email))
                    return user;
            }

            return new User();
        }

        public static async Task<User> AddUser(User user)
        {

            var client = new HttpClient();
<<<<<<< HEAD
            var url = ash.JsonObject.DatabasePath.ToString() + "/api/user";
=======
            var url = "http://18.188.13.94/DataSvc/api/user";
>>>>>>> master
            var uri = new Uri(url);
            var data = JsonConvert.SerializeObject(user);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(uri, stringContent);

            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("result: {0}", result.StatusCode);
                return user;
            }

            return null;
        }
    }
}
