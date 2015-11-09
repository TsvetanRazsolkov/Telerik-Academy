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
    using MusicSystem.Web.Models;
    using MusicSystem.Models;

    public class Program
    {
        // This client does not work for some reason, will find out what soon :)
        // Tests can be made through Postman for the moment :(
        public static void Main()
        {
            var uri = new Uri("http://localhost:58554/");

            PostSong(uri, "Te sa zeleni", 2010, 2);
            PostSong(uri, "Te sa cherveni", 2010, 2);
            PostSong(uri, "Te sa lilavi", 2010, 2);

        }

        private static void PostSong(Uri uri, string title, int year, int genre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;

                Console.WriteLine("Creating song");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var song = new SongViewModel
                {
                    Title = title,
                    Year = year,
                    Genre = (GenreType)genre
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("api/Songs/Create", httpContent).Result;

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
