namespace MusicSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;

    using Data.Repositories;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;

    public class Program
    {
        // This client does not work for some reason, will find out what soon :)
        // Tests can be made through Postman for the moment :(
        public static void Main()
        {
            //var uri = new Uri("http://localhost:58554/");

            //PostSong(uri, "Te sa zeleni", 2010, "HipHop");
            //PostSong(uri, "Te sa cherveni", 2010, "HipHop");
            //PostSong(uri, "Te sa lilavi", 2010, "HipHop");

        }

        private static void PostSong(Uri uri, string title, int year, string genre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;

                Console.WriteLine("Creating song");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new
                 {
                     Title = title,
                     Year = year,
                     Genre = genre
                 });

                var content = new StringContent(json);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PostAsync("api/Songs/Create", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Created");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }
    }
}
