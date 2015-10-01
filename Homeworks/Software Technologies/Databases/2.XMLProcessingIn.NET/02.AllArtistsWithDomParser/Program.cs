namespace _02.AllArtistsWithDomParser
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class Program
    {
        public static void Main()
        {

            var catalog = new XmlDocument();
            catalog.Load("../../../catalog.xml");

            var root = catalog.DocumentElement;

            var uniqueArtists = GetUniqueArtists(root);

            foreach (var artist in uniqueArtists)
            {
                Console.WriteLine("Artist {0} has {1} albums in the catalog.", artist.Key, artist.Value);
            }
        }

        private static IDictionary<string, int> GetUniqueArtists(XmlElement root)
        {
            var allArtists = root.GetElementsByTagName("artist");

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
