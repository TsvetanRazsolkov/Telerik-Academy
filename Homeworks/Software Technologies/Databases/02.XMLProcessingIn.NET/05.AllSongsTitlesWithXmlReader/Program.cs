namespace _05.AllSongsTitlesWithXmlReader
{
    using System;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("All songs titles from catalog using XMLReader:");

            using (var reader = XmlReader.Create("../../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element
                        && reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
