namespace _03.AllArtistsWithXPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            var catalog = new XmlDocument();
            catalog.Load("../../../catalog.xml");

            string xPathQuery = "/albums/album/artist";

            var allArtistsElements = catalog.SelectNodes(xPathQuery);

            var uniqueArtists = GetUniqueArtists(allArtistsElements);
            foreach (var artist in uniqueArtists)
            {
                Console.WriteLine("Artist {0} has {1} albums in the catalog.", artist.Key, artist.Value);
            }

        }

        private static IDictionary<string, int> GetUniqueArtists(XmlNodeList allArtists)
        {
            var result = new Dictionary<string, int>();
            foreach (XmlElement artist in allArtists)
            {
                string artistName = artist.InnerText;
                if (result.ContainsKey(artistName))
                {
                    result[artistName]++;
                }
                else
                {
                    result.Add(artistName, 1);
                }
            }

            return result;
        }
    }
}
