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

            var root = catalog.DocumentElement;
            var albums = root.GetElementsByTagName("album");
			
            for (int i = albums.Count - 1; i >= 0; i--)
            {
                var album = albums[i];
				
                decimal albumPrice = decimal.Parse(album["price"].InnerText);
                if (albumPrice > 20)
                {
                    album.ParentNode.RemoveChild(album);
                }
            }   

            catalog.Save("../../../catalogWithDeletedAlbums.xml");             
        }
    }
}
