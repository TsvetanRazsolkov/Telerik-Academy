namespace DoThatThing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.IO;

    class Program
    {
        static void Main()
        {
            string rssUrl = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            string xmlFilePath = "../../feed.xml";
            string htmlFilePath = "../../videos.html";

            // donwolading the file
            using (WebClient downloader = new WebClient())
            {
                downloader.DownloadFile(rssUrl, xmlFilePath);
            }

            // Parse teh XML from the feed to JSON
            var xmlFeed = XDocument.Load(xmlFilePath);
            string jsonFeedAsString = JsonConvert.SerializeXNode(xmlFeed, Formatting.Indented);
            var jsonFeed = JObject.Parse(jsonFeedAsString);

            // Using LINQ-to-JSON select all the video titles and print the on the console
            var videoTitles = jsonFeed["feed"]["entry"].Select(e => e["title"]);
            foreach (var title in videoTitles)
            {
                Console.WriteLine(title);
            }

            // Parse the videos' JSON to POCO
            IEnumerable<Video> videos = jsonFeed["feed"]["entry"].
                            Select(e => JsonConvert.DeserializeObject<Video>(e.ToString()));

            // Using the POCOs create a HTML page that shows all videos from the RSS
            string htmlString = GetHtmlString(videos);
            using (StreamWriter writer = new StreamWriter(htmlFilePath, false, Encoding.UTF8))
            {
                writer.Write(htmlString);
            }

            Console.WriteLine("You will find the videos.html file in the project's main directory.");
        }

        private static string GetHtmlString(IEnumerable<Video> videos)
        {
            StringBuilder htmlString = new StringBuilder();

            htmlString.Append("<!DOCTYPE html><html><body>");
            htmlString.Append("<h2>Gotta love the styling...</h2>");

            foreach (var video in videos)
            {
                htmlString.AppendFormat("<div style=\"padding:5px; margin:0px; margin-bottom:10px\">" +
                                  "<iframe " +
                                  "src=\"http://www.youtube.com/embed/{1}\" " +
                                  " allowfullscreen></iframe>" +
                                  "<h4>{2}</h4><a href=\"{0}\">Watch on YouTube</a></div>",
                                  video.Link.Href, video.Id, video.Title);
            }

            return htmlString.ToString();
        }
    }
}
