using System;
using System.IO;

// Write a program that reads a text file and inserts line numbers in front of each of its
// lines. The result should be written to another text file.

class LineNumbers
{
    const string pathInput = "..\\..\\input.txt";
    const string pathOutput = "..\\..\\result.txt";

    static void Main()
    {
        StreamReader reader = new StreamReader(pathInput);
        StreamWriter writer = new StreamWriter(pathOutput);
        string currentLine = string.Empty;
        using (reader)
        using (writer)
        {
            int lineNumber = 1;
            while (!reader.EndOfStream)
            {
                currentLine = reader.ReadLine();
                writer.WriteLine("{0}. {1}", lineNumber, currentLine);
                lineNumber++;
            }
        }
        Console.WriteLine("Done!");
    }
}