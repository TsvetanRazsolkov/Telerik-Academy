namespace _13_14.XmlToHtmlWithXslTransform
{
    using System;
    using System.Xml.Xsl;

    class Program
    {
        static void Main()
        {
            string styleSheetPath = "../../catalogStyleSheet.xsl";
            string catalogXmlPath = "../../../catalog.xml";
            string catalogHtmlPath = "../../catalog.html";

            XslCompiledTransform optimusPrime = new XslCompiledTransform();
            optimusPrime.Load(styleSheetPath);
            optimusPrime.Transform(catalogXmlPath, catalogHtmlPath);

            Console.WriteLine("You will find the created catalog.html file in the main directory of the project.");
        }
    }
}
