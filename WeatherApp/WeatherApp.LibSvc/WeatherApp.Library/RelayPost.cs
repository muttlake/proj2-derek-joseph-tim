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
            //Pass to DataSvc
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(requestBody);
                var response = await client.PostAsync(uri, stringContent);
            }

        }
    }
}
