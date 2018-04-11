using System;
using System.IO;
using System.Net;
using WeatherApp.Library;

namespace WeatherApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            //ReadFromOpenWeatherMap();

            ReadFromOpenWeatherMapZips();

            // using (var db = new WeatherAppContext()) 
            // { 
            //     // Create and save a new Blog 
            //     Console.Write("Enter Stop to Stop: "); 
            //     var stop = Console.ReadLine(); 
    
            //     while (!stop.Equals("Stop"))
            //     {
            //         Console.WriteLine("Enter UserID: ");
            //         var uid = Convert.ToInt32(Console.ReadLine());
            //         Console.WriteLine("Enter BlogPost: ");
            //         var blog = Console.ReadLine();
            //         Console.WriteLine("Enter ImageFile: ");
            //         var image = Console.ReadLine();
 
            //         var post = new Post(uid, blog, image);
            //         db.Posts.Add(post); 
            //         db.SaveChanges(); 
                                    
            //         Console.Write("Enter Stop to Stop: "); 
            //         stop = Console.ReadLine(); 
            //     }
                
                // // Display all Blogs from the database 
                // var query = from b in db.Users 
                //             select b; 
    
                // Console.WriteLine("All users in the database:"); 
                // foreach (var item in query) 
                // { 
                //     Console.WriteLine(item.FirstName); 
                // } 
    
                // Console.WriteLine("Press any key to exit..."); 
                // Console.ReadKey(); 
            //}
        }

        static void ReadFromOpenWeatherMap()
        {

            string apiKey = "a6acab0d579d6ac71c21659ff3de726d";
            //api.openweathermap.org/data/2.5/weather?q={city name}
            //api.openweathermap.org/data/2.5/weather?zip=94040,us
            HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?zip=28215,us&appid=" + apiKey ) as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
            Console.WriteLine(apiResponse);
        }

        static void ReadFromOpenWeatherMapZips()
        {
            var jr = new JsonReader();

            Console.Write("Enter Stop to Stop: "); 
            var stop = Console.ReadLine(); 

            while (!stop.Equals("Stop"))
            {
                Console.WriteLine("Enter ZipCode: ");
                int zip = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n\nPrinting weather for zip code: ");
                jr.ZipCode = zip;
                jr.PrintWeatherForZip();
                                
                Console.Write("Enter Stop to Stop: "); 
                stop = Console.ReadLine(); 
            }

        }

    }
}
