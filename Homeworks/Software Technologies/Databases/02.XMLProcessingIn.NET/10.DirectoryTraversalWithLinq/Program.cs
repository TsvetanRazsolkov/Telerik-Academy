namespace _10.DirectoryTraversalWithLinq
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("You will find the created directoryTraversal.xml file in the main directory of the project.");
            Console.WriteLine("It might take a while if you have poor Desktop space management :)");

            string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var directoryTraversal = Traverse(directoryPath);
            directoryTraversal.Save("../../directoryTraversal.xml");
        }

        private static XElement Traverse(string directoryPath)
        {
            var element = new XElement("dir", new XAttribute("name", new DirectoryInfo(directoryPath).Name));

            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
                element.Add(Traverse(directory));
            }

            foreach (var file in Directory.GetFiles(directoryPath))
            {
                var currentFile = new XElement("file", 
                new XAttribute("name", Path.GetFileName(file)),
                new XAttribute("type", Path.GetExtension(file)));

                element.Add(currentFile);
            }

            return element;
        }
    }
}
