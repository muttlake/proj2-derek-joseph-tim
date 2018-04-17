// using file for adding images to imgur using RestSharp
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
//other using files

namespace WeatherApp.ClientLib
{
    public class ImageHandler
    {
        // code for adding images to web site folder

        //public ImageHandler()
        //{
        //}

        //public void AddImage()
        //{
        //    try
        //    {
        //        File.Copy(@"c:\Images\hawaiian-pizza.jpg", @"\\WeatherApp\WeatherApp.LibSvc\WeatherApp.Library\Images\hawaiian-pizza.jpg", false);
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine("Exception " + ex + " occurred at line 22 ImageHandler.AddImage\n" );
        //    }
        //}

        // code for adding images to imgur

        string token = "f0f55d13-09ad-4a83-9dcb-82150fd7d805";
        string auth = "Bearer 5f59e946914c966d89ecb5a2f64f6717fa96f682";

        // session variables
        string imgUrl;
        // name of the file shown in imgur
        //string imgTitle;
        //// description of file in imgur
        //string imgDescription;
        //// gile name
        //string imgName;
        //string imgType;

        public void AddImage()
        {
            //imgUrl = "R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7";
            imgUrl = @"c:\Images\hawaiian-pizza.jpg";
            //imgTitle = "jpg image";
            //imgDescription = "this is a jpg image";
            //var imgName = "img.jpg";
            //var imgType = "jpg";

            PostImage();
        }

        public void AddImage(string url)
        {
            imgUrl = url;
            //imgTitle = title;
            //imgDescription = desc;
            //imgName = name;
            //imgType = type;

            PostImage();
        }

        public void PostImage()
        {
            var client = new RestClient("https://api.imgur.com/3/image");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Postman-Token", token);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", auth);
            request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
            request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW",
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                "Content-Disposition: form-data; name=\"image\"\r\n\r\n" +

                imgUrl + "\r\n" +
            //    "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
            //    "Content-Disposition: form-data; name=\"title\"\r\n\r\n" +

            //    //imgTitle + "\r\n" +
            //    "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
            //    "Content-Disposition: form-data; name=\"description\"\r\n\r\n" +

            //    //imgDescription + "\r\n" +
            //    "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
            //    "Content-Disposition: form-data; name=\"name\"\r\n\r\n" +

            //    //imgName + "\r\n" +
            //    "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
            //    "Content-Disposition: form-data; name=\"type\"\r\n\r\n" +

            //    //imgType + "\r\n" +
                "------WebKitFormBoundary7MA4YWxkTrZu0gW--",
                ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
    }
}
