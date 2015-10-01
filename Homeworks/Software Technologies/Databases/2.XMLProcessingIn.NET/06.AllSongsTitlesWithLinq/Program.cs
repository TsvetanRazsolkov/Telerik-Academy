namespace _06.AllSongsTitlesWithLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("All songs titles from catalog using LINQ:");

            var catalog = XDocument.Load("../../../catalog.xml");

            var songsTitles = from song in catalog.Descendants("song")
                              select song.Element("title").Value;

            foreach (var songTitle in songsTitles)
            {
                Console.WriteLine(songTitle);
            }
        }
    }
}
