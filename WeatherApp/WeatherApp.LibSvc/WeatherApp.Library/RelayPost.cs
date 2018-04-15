using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace WeatherApp.Library
{
    public class RelayPost
    {
        public RelayPost()
        {

        }


        public async void RelayAddToDataSvc(Uri uri, string requestBody)
        {
            Console.WriteLine("\n\n\nRelayAddToDataSvc");

            //Pass to DataSvc
            using (var client = new HttpClient())
            {

                var stringContent = new StringContent(requestBody);
                Console.WriteLine("StringContent for post");
                Console.WriteLine(stringContent.ToString());
                //var uri = new Uri("http://localhost:9000/api/post");
                var response = await client.PostAsync(uri, stringContent);
                Console.WriteLine("response result {0}", response.StatusCode);
                Console.WriteLine("response is completed {0}", response.RequestMessage);

            }

        }
    }
}
