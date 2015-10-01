namespace _12.ExtractAlbumPricesFromCatalogWithLinq
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    class Program
    {
        static void Main()
        {
            var catalog = XDocument.Load("../../../catalog.xml");

            int targetYear = DateTime.Now.Year - 5;

            var fiveYearAndMoreOldAlbums = catalog.Descendants("album")
                .Where(a => int.Parse(a.Element("year").Value) <= targetYear)
                .Select(a => new 
                {
                    name = a.Element("name").Value,
                    artist = a.Element("artist").Value,
                    year = a.Element("year").Value,
                    price = decimal.Parse(a.Element("price").Value)
                });

            foreach (var album in fiveYearAndMoreOldAlbums)
            {
                Console.WriteLine("Album name: {0}, Artist: {1} Year: {2}, Price: {3}",
                    album.name, album.artist, album.year, album.price);
            }
        }
    }
}
