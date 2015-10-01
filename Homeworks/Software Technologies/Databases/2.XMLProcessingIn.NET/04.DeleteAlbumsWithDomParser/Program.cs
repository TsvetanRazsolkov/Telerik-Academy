namespace _04.DeleteAlbumsWithDomParser
{
    using System;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            var catalog = new XmlDocument();
            catalog.Load("../../../catalog.xml");

            var albums = catalog.DocumentElement;

            foreach (XmlNode album in albums)
            {
                var albumPrice = decimal.Parse(album["price"].InnerText);
                if (albumPrice > 20)
                {
                    albums.RemoveChild(album);
                }
            }

            catalog.Save("../../../catalogWithDeletedAlbums.xml");             
        }
    }
}
