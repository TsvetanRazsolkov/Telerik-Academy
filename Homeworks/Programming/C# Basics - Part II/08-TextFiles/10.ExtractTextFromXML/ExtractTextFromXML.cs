using System;
using System.IO;
using System.Text;

/* Write a program that extracts from given XML file all the text without the tags.
Example:
<?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3"><interest>Games
</interest><interest>C#</interest><interest>Java</interest></interests></student>   */

class ExtractTextFromXML
{
    const string inputPath = "..\\..\\xmlFile.txt";
    const string outputPath = "..\\..\\textOutput.txt";

    static void Main()
    {
        StreamReader reader = new StreamReader(inputPath);

        string text;
        using (reader)
        {
            text = reader.ReadToEnd();
        }
        PrintExtractedText(text);
    }

    static void PrintExtractedText(string text)
    {
        StringBuilder sb = new StringBuilder();
        bool insideTag = false;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '<')
            {
                insideTag = true;
            }
            if (!insideTag)
            {
                sb.Append(text[i]);
            }
            if (text[i] == '>')
            {
                sb.Append(" ");
                insideTag = false;
            }
        }
        string[] resultText = sb.ToString().Split(new char[] { ' ' },
                           StringSplitOptions.RemoveEmptyEntries);

        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            foreach (string word in resultText)
            {
                writer.WriteLine(word);
            }
        }
    }
}