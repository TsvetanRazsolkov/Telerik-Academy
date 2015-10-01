namespace _07.XmlDocumentFromTextFile
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            string xmlFilePath = "../../person.xml";
            string textFilePath = "../../person.txt";

            using (var reader = new StreamReader(textFilePath))
            {
                using (var writer = new XmlTextWriter(xmlFilePath, Encoding.UTF8))
                {
                    string name = reader.ReadLine();
                    string address = reader.ReadLine();
                    string phone = reader.ReadLine();

                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("person");
                    writer.WriteElementString("name", name);
                    writer.WriteElementString("address", address);
                    writer.WriteElementString("phone", phone);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();                    
                }
            }

            Console.WriteLine("You will find the created person.xml file in the main directory of the project.");
        }
    }
}
