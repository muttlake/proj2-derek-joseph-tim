using System;
using WeatherApp.Library;

namespace WeatherApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var db = new WeatherAppContext()) 
            { 
                // Create and save a new Blog 
                Console.Write("Enter Stop to Stop: "); 
                var stop = Console.ReadLine(); 
    
                while (!stop.Equals("Stop"))
                {
                    Console.WriteLine("Enter UserID: ");
                    var uid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter BlogPost: ");
                    var blog = Console.ReadLine();
                    Console.WriteLine("Enter ImageFile: ");
                    var image = Console.ReadLine();
 
                    var post = new Post(uid, blog, image);
                    db.Posts.Add(post); 
                    db.SaveChanges(); 
                                    
                    Console.Write("Enter Stop to Stop: "); 
                    stop = Console.ReadLine(); 
                }
                
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
            }
        }
    }
}
