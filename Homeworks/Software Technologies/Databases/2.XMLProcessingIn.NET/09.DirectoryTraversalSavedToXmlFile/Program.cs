namespace _09.DirectoryTraversalSavedToXmlFile
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    class Program
    {
        static void Main()
        {            
            string xmlFilePath = "../../directoryTraversal.xml";

            Console.WriteLine("You will find the created directoryTraversal.xml file in the main directory of the project.");
            Console.WriteLine("It might take a while if you have poor Desktop space management :)");

            using (var writer = new XmlTextWriter(xmlFilePath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 1;
                writer.IndentChar = '\t';


                string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                writer.WriteStartDocument();
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", new DirectoryInfo(directoryPath).Name);

                Traverse(directoryPath, writer);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void Traverse(string directoryPath, XmlTextWriter writer)
        {
            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", new DirectoryInfo(directory).Name);
                Traverse(directory, writer);
                writer.WriteEndElement();
            }

            foreach (var file in Directory.GetFiles(directoryPath))
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", Path.GetFileName(file));
                writer.WriteAttributeString("type", Path.GetExtension(file));
                writer.WriteEndElement();
            }
        }
    }
}
