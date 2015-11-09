
/*Write a console application, which searches for news articles by given a query stringand a count of articles to retrieve.
The application should ask the user for input and print the Titles and URLs of the articles.
For news articles search, use the Feedzilla API and use one of WebClient, HttpWebRequest or HttpClient.
Feedzilla is pretty dead right now, so another public API is used with similar effect - http://jsonplaceholder.typicode.com*/
namespace _03.ConsumeWebServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    using Newtonsoft.Json;
    using System.Net.Http.Headers;

    public class Startup
    {
        public static void Main()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://jsonplaceholder.typicode.com");

            Console.Write("Enter query string: (default value is dolorem): ");
            string queryString = Console.ReadLine();
            if (string.IsNullOrEmpty(queryString))
            {
                queryString = "dolorem";
            }

            Console.Write("Enter number of items: (default value is 10) ");
            int numberOfItems;
            bool validNumber = int.TryParse(Console.ReadLine(), out numberOfItems);
            if (!validNumber)
            {
                numberOfItems = 10;
            }

            PrintPosts(httpClient, numberOfItems, queryString);
            Console.WriteLine("Getting your result...");
            Console.ReadLine();
        }

        private static async void PrintPosts(HttpClient httpClient, int numberOfItems, string query)
        {
            var response = await httpClient.GetAsync("posts");

            var text = response.Content.ReadAsStringAsync().Result;
            var jsons = JsonConvert.DeserializeObject<List<PostResponseModel>>(text);
            var filtered = jsons.Where(x => x.Title.Contains(query) || x.Body.Contains(query)).Take(numberOfItems);

            foreach (var post in filtered)
            {
                Console.WriteLine("Title: {0}, ID: {1}", post.Title, post.Id);
            }

            Console.WriteLine("To exit press ENTER:");
        }
    }
}
