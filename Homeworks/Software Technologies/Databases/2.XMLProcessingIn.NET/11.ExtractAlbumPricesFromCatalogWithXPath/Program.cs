namespace _11.ExtractAlbumPricesFromCatalogWithXPath
{
    using System;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            var catalog = new XmlDocument();
            catalog.Load("../../../catalog.xml");
            int targetYear = DateTime.Now.Year - 5;

            string xPathQuery = "/albums/album[year <= " + targetYear + "]";

            XmlNodeList albumsOlderThanFourYears = catalog.SelectNodes(xPathQuery);

            foreach (XmlNode album in albumsOlderThanFourYears)
            {
                Console.WriteLine("Album name: {0}, Artist: {1} Year: {2}, Price: {3}",
                    album["name"].InnerText, album["artist"].InnerText, album["year"].InnerText, album["price"].InnerText);
            }
        }
    }
}
