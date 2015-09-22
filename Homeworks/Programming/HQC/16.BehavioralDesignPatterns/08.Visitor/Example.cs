namespace _08.Visitor
{
    using System;
    using System.Collections.Generic;

    using DocumentStrucuture;

    public class Example
    {
        public static void Main()
        {
            Document doc = new Document(
                                     new List<DocumentPart>()
                                     {
                                         new PlainText("Az sym Pesho, kakto se ochakvashe."),
                                         new BoldText("Pesho."),
                                         new Hyperlink("Go to Pesho's website.", "http://pesho.com")
                                     });

            // Could have other formatter in the form of a visitor
            var htmlConverter = new HtmlVisitor();

            doc.Accept(htmlConverter);
            Console.WriteLine("HTML: \n{0}", htmlConverter.Output);
        }
    }
}
