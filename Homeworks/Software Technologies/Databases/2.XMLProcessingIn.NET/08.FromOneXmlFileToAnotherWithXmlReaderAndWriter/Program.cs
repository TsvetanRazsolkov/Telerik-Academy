namespace _08.FromOneXmlFileToAnotherWithXmlReaderAndWriter
{
    using System;
    using System.Text;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            string catalogFilePath = "../../../catalog.xml";
            string albumsFilePath = "../../albums.xml";

            using (var reader = XmlReader.Create(catalogFilePath))
            {
                using (var writer = new XmlTextWriter(albumsFilePath, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.Indentation = 1;
                    writer.IndentChar = '\t';

                    writer.WriteStartDocument(); 
                    writer.WriteStartElement("albums");

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "name")
                            {
                                writer.WriteStartElement("album");
                                writer.WriteElementString("name", reader.ReadElementString());
                            }
                            else if (reader.Name == "artist")
                            {
                                writer.WriteElementString("artist", reader.ReadElementString());
                                writer.WriteEndElement();
                            }
                        }
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }

            Console.WriteLine("You will find the created albums.xml file in the main directory of the project.");
        }
    }
}
